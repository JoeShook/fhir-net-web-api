﻿using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Utility;
using Hl7.Fhir.WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Health.Fhir.Facade.SqlServer
{
    /// <summary>
    /// This is an implementation of the FHIR Service that sources all its files in the file system
    /// </summary>
    public class MSR_SystemService<TSP> : Hl7.Fhir.WebApi.IFhirSystemServiceR4<TSP>
        where TSP : class
    {
        public MSR_SystemService()
        {
        }

        /// <summary>
        /// The File system directory that will be scanned for the storage of FHIR resources
        /// </summary>
        public int DefaultPageSize { get; set; } = 40;

        private EntityModels.FHIR_R4Context GetMsFhirDbContext(TSP services)
        {
            if (services is System.IServiceProvider sp)
            {
                return sp.GetService<EntityModels.FHIR_R4Context>();
            }
            return null;
        }

        public async System.Threading.Tasks.Task<CapabilityStatement> GetConformance(ModelBaseInputs<TSP> request, SummaryType summary)
        {
            Hl7.Fhir.Model.CapabilityStatement con = new Hl7.Fhir.Model.CapabilityStatement();
            con.Url = request.BaseUri + "metadata";
            con.Description = new Markdown("POC Terminology Integrated Microsoft FHIR Server");
            con.Publisher = "Microsoft Research";
            con.DateElement = new Hl7.Fhir.Model.FhirDateTime("2017-04-30");
            con.Version = "1.0.0.0";
            con.Name = "demoCapStmt";
            con.Experimental = true;
            con.Status = PublicationStatus.Active;
            con.FhirVersion = FHIRVersion.N4_0_1;
            con.Format = new string[] { "xml", "json" };
            con.Kind = CapabilityStatementKind.Instance;
            con.Meta = new Meta();
            con.Meta.LastUpdatedElement = Instant.Now();

            con.Rest = new List<Hl7.Fhir.Model.CapabilityStatement.RestComponent>
            {
                new Hl7.Fhir.Model.CapabilityStatement.RestComponent()
                {
                    Operation = new List<Hl7.Fhir.Model.CapabilityStatement.OperationComponent>()
                }
            };
            con.Rest[0].Mode = CapabilityStatement.RestfulCapabilityMode.Server;
            con.Rest[0].Resource = new List<Hl7.Fhir.Model.CapabilityStatement.ResourceComponent>();

            foreach (var resName in ModelInfo.SupportedResources)
            {
                var c = await GetResourceService(request, resName).GetRestResourceComponent();
                if (c != null)
                    con.Rest[0].Resource.Add(c);
            }

            return con;
        }

        public IFhirResourceServiceR4<TSP> GetResourceService(ModelBaseInputs<TSP> request, string resourceName)
        {
            var msDB = GetMsFhirDbContext(request.ServiceProvider);
            var rtID = msDB.ResourceType.Where(rt => rt.Name == resourceName).Select(rt => rt.ResourceTypeId).FirstOrDefault();
            var sps = ModelInfo.SearchParameters.Where(sp => sp.Resource == resourceName).Select(sp => new { sp.Url, sp.Name }).ToDictionary(d => d.Url);
            Dictionary<string, short> spIdcache = new Dictionary<string, short>();
            foreach (var sp in msDB.SearchParam.Where(sp => sps.Values.Select(t => t.Url).Contains(sp.Uri) && sp.Status == "Enabled"))
            {
                spIdcache.Add(sps[sp.Uri].Name, sp.SearchParamId);
            }
            return new MSR_ResourceService<TSP>()
            {
                RequestDetails = request,
                ResourceName = resourceName,
                dbMS = msDB,
                ResourceTypeId = rtID,
                SearchParamIdCache = spIdcache
            };
        }

        public System.Threading.Tasks.Task<Resource> PerformOperation(ModelBaseInputs<TSP> request, string operation, Parameters operationParameters, SummaryType summary)
        {
            if (operation == "convert")
            {
                Resource resource = operationParameters.GetResource("input");
                if (resource != null)
                    return System.Threading.Tasks.Task.FromResult(resource);
                OperationOutcome outcome = new OperationOutcome();
                outcome.Issue.Add(new OperationOutcome.IssueComponent()
                {
                    Severity = OperationOutcome.IssueSeverity.Error,
                    Code = OperationOutcome.IssueType.Value,
                    Details = new CodeableConcept() { Text = "Missing resource to convert" }
                });
                return System.Threading.Tasks.Task.FromResult<Resource>(outcome);
            }

            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task<Bundle> ProcessBatch(ModelBaseInputs<TSP> request, Bundle batch)
        {
            BatchOperationProcessing<TSP> batchProcessor = new BatchOperationProcessing<TSP>();
            batchProcessor.DefaultPageSize = DefaultPageSize;
            batchProcessor.GetResourceService = GetResourceService;
            return await batchProcessor.ProcessBatch(request, batch);
        }

        public System.Threading.Tasks.Task<Bundle> Search(ModelBaseInputs<TSP> request, IEnumerable<KeyValuePair<string, string>> parameters, int? Count, SummaryType summary)
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task<Bundle> SystemHistory(ModelBaseInputs<TSP> request, DateTimeOffset? since, DateTimeOffset? Till, int? Count, SummaryType summary)
        {
            Bundle result = new Bundle();
            result.Meta = new Meta()
            {
                LastUpdated = System.DateTime.Now
            };
            result.Id = new Uri("urn:uuid:" + Guid.NewGuid().ToString("n")).OriginalString;
            result.Type = Bundle.BundleType.History;

            using (var msDB = GetMsFhirDbContext(request.ServiceProvider))
            {
                var table = msDB.Resource.Take(Count ?? 20); // Default Table Size if none requested
                foreach (var row in await table.ToArrayAsync(request.CancellationToken))
                {
                    Resource resource = null;
                    if (!row.IsDeleted)
                    {
                        resource = RawResourceSerializer.Deserialize(row.RawResource);
                        resource.Meta.VersionId = row.Version.ToString(); // why is not the version in the raw data...
                    }
                    var ri = ResourceIdentity.Build(request.BaseUri, resource.TypeName, row.ResourceId, row.Version.ToString());
                    result.Entry.Add(new Bundle.EntryComponent()
                    {
                        Resource = resource,
                        FullUrl = ri.OriginalString,
                        Request = new Bundle.RequestComponent()
                        {
                            Method = row.IsDeleted ? Bundle.HTTPVerb.DELETE : Hl7.Fhir.Utility.EnumUtility.ParseLiteral<Bundle.HTTPVerb>(row.RequestMethod),
                            Url = $"{resource.TypeName}/{row.ResourceId}/_history/{row.Version}"
                        },
                    });
                }
                // also need to set the page links
            }

            return result;
        }
    }
}