﻿// -----------------------------------------------------------------------------
// GENERATED CODE - DO NOT EDIT
// -----------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Threading;

namespace Hl7.Fhir.CustomSerializer
{
    public partial class FhirCustomXmlReader
    {
		public void Parse(Hl7.Fhir.Model.CoverageEligibilityResponse.ItemsComponent result, XmlReader reader, OperationOutcome outcome, string locationPath)
		{
			// skip ignored elements
			while (ShouldSkipNodeType(reader.NodeType))
				if (!reader.Read())
					return;
			
			if (reader.MoveToFirstAttribute())
			{
				do
				{
					switch (reader.Name)
					{
						case "id":
							result.ElementId = reader.Value;
							break;
					}
				} while (reader.MoveToNextAttribute());
				reader.MoveToElement();
			}

			if (reader.IsEmptyElement)
				return;

			// otherwise proceed to read all the other nodes
			while (reader.Read())
			{
				if (reader.IsStartElement())
				{
					switch (reader.Name)
					{
						case "extension":
							var newItem_extension = new Hl7.Fhir.Model.Extension();
							Parse(newItem_extension, reader, outcome, locationPath + ".extension["+result.Extension.Count+"]"); // 20
							result.Extension.Add(newItem_extension);
							break;
						case "modifierExtension":
							var newItem_modifierExtension = new Hl7.Fhir.Model.Extension();
							Parse(newItem_modifierExtension, reader, outcome, locationPath + ".modifierExtension["+result.ModifierExtension.Count+"]"); // 30
							result.ModifierExtension.Add(newItem_modifierExtension);
							break;
						case "category":
							result.Category = new Hl7.Fhir.Model.CodeableConcept();
							Parse(result.Category as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".category"); // 40
							break;
						case "productOrService":
							result.ProductOrService = new Hl7.Fhir.Model.CodeableConcept();
							Parse(result.ProductOrService as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".productOrService"); // 50
							break;
						case "modifier":
							var newItem_modifier = new Hl7.Fhir.Model.CodeableConcept();
							Parse(newItem_modifier, reader, outcome, locationPath + ".modifier["+result.Modifier.Count+"]"); // 60
							result.Modifier.Add(newItem_modifier);
							break;
						case "provider":
							result.Provider = new Hl7.Fhir.Model.ResourceReference();
							Parse(result.Provider as Hl7.Fhir.Model.ResourceReference, reader, outcome, locationPath + ".provider"); // 70
							break;
						case "excluded":
							result.ExcludedElement = new Hl7.Fhir.Model.FhirBoolean();
							Parse(result.ExcludedElement as Hl7.Fhir.Model.FhirBoolean, reader, outcome, locationPath + ".excluded"); // 80
							break;
						case "name":
							result.NameElement = new Hl7.Fhir.Model.FhirString();
							Parse(result.NameElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".name"); // 90
							break;
						case "description":
							result.DescriptionElement = new Hl7.Fhir.Model.FhirString();
							Parse(result.DescriptionElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".description"); // 100
							break;
						case "network":
							result.Network = new Hl7.Fhir.Model.CodeableConcept();
							Parse(result.Network as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".network"); // 110
							break;
						case "unit":
							result.Unit = new Hl7.Fhir.Model.CodeableConcept();
							Parse(result.Unit as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".unit"); // 120
							break;
						case "term":
							result.Term = new Hl7.Fhir.Model.CodeableConcept();
							Parse(result.Term as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".term"); // 130
							break;
						case "benefit":
							var newItem_benefit = new Hl7.Fhir.Model.CoverageEligibilityResponse.BenefitComponent();
							Parse(newItem_benefit, reader, outcome, locationPath + ".benefit["+result.Benefit.Count+"]"); // 140
							result.Benefit.Add(newItem_benefit);
							break;
						case "authorizationRequired":
							result.AuthorizationRequiredElement = new Hl7.Fhir.Model.FhirBoolean();
							Parse(result.AuthorizationRequiredElement as Hl7.Fhir.Model.FhirBoolean, reader, outcome, locationPath + ".authorizationRequired"); // 150
							break;
						case "authorizationSupporting":
							var newItem_authorizationSupporting = new Hl7.Fhir.Model.CodeableConcept();
							Parse(newItem_authorizationSupporting, reader, outcome, locationPath + ".authorizationSupporting["+result.AuthorizationSupporting.Count+"]"); // 160
							result.AuthorizationSupporting.Add(newItem_authorizationSupporting);
							break;
						case "authorizationUrl":
							result.AuthorizationUrlElement = new Hl7.Fhir.Model.FhirUri();
							Parse(result.AuthorizationUrlElement as Hl7.Fhir.Model.FhirUri, reader, outcome, locationPath + ".authorizationUrl"); // 170
							break;
						default:
							// Property not found
							HandlePropertyNotFound(reader, outcome, locationPath + "." + reader.Name);
							break;
					}
				}
				else if (reader.NodeType == XmlNodeType.EndElement || reader.IsStartElement() && reader.IsEmptyElement)
				{
					break;
				}
			}
		}

		public async System.Threading.Tasks.Task ParseAsync(Hl7.Fhir.Model.CoverageEligibilityResponse.ItemsComponent result, XmlReader reader, OperationOutcome outcome, string locationPath)
		{
			// skip ignored elements
			while (ShouldSkipNodeType(reader.NodeType))
				if (!await reader.ReadAsync().ConfigureAwait(false))
					return;
			
			if (reader.MoveToFirstAttribute())
			{
				do
				{
					switch (reader.Name)
					{
						case "id":
							result.ElementId = reader.Value;
							break;
					}
				} while (reader.MoveToNextAttribute());
				reader.MoveToElement();
			}

			if (reader.IsEmptyElement)
				return;

			// otherwise proceed to read all the other nodes
			while (await reader.ReadAsync().ConfigureAwait(false))
			{
				if (reader.IsStartElement())
				{
					switch (reader.Name)
					{
						case "extension":
							var newItem_extension = new Hl7.Fhir.Model.Extension();
							await ParseAsync(newItem_extension, reader, outcome, locationPath + ".extension["+result.Extension.Count+"]"); // 20
							result.Extension.Add(newItem_extension);
							break;
						case "modifierExtension":
							var newItem_modifierExtension = new Hl7.Fhir.Model.Extension();
							await ParseAsync(newItem_modifierExtension, reader, outcome, locationPath + ".modifierExtension["+result.ModifierExtension.Count+"]"); // 30
							result.ModifierExtension.Add(newItem_modifierExtension);
							break;
						case "category":
							result.Category = new Hl7.Fhir.Model.CodeableConcept();
							await ParseAsync(result.Category as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".category"); // 40
							break;
						case "productOrService":
							result.ProductOrService = new Hl7.Fhir.Model.CodeableConcept();
							await ParseAsync(result.ProductOrService as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".productOrService"); // 50
							break;
						case "modifier":
							var newItem_modifier = new Hl7.Fhir.Model.CodeableConcept();
							await ParseAsync(newItem_modifier, reader, outcome, locationPath + ".modifier["+result.Modifier.Count+"]"); // 60
							result.Modifier.Add(newItem_modifier);
							break;
						case "provider":
							result.Provider = new Hl7.Fhir.Model.ResourceReference();
							await ParseAsync(result.Provider as Hl7.Fhir.Model.ResourceReference, reader, outcome, locationPath + ".provider"); // 70
							break;
						case "excluded":
							result.ExcludedElement = new Hl7.Fhir.Model.FhirBoolean();
							await ParseAsync(result.ExcludedElement as Hl7.Fhir.Model.FhirBoolean, reader, outcome, locationPath + ".excluded"); // 80
							break;
						case "name":
							result.NameElement = new Hl7.Fhir.Model.FhirString();
							await ParseAsync(result.NameElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".name"); // 90
							break;
						case "description":
							result.DescriptionElement = new Hl7.Fhir.Model.FhirString();
							await ParseAsync(result.DescriptionElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".description"); // 100
							break;
						case "network":
							result.Network = new Hl7.Fhir.Model.CodeableConcept();
							await ParseAsync(result.Network as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".network"); // 110
							break;
						case "unit":
							result.Unit = new Hl7.Fhir.Model.CodeableConcept();
							await ParseAsync(result.Unit as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".unit"); // 120
							break;
						case "term":
							result.Term = new Hl7.Fhir.Model.CodeableConcept();
							await ParseAsync(result.Term as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".term"); // 130
							break;
						case "benefit":
							var newItem_benefit = new Hl7.Fhir.Model.CoverageEligibilityResponse.BenefitComponent();
							await ParseAsync(newItem_benefit, reader, outcome, locationPath + ".benefit["+result.Benefit.Count+"]"); // 140
							result.Benefit.Add(newItem_benefit);
							break;
						case "authorizationRequired":
							result.AuthorizationRequiredElement = new Hl7.Fhir.Model.FhirBoolean();
							await ParseAsync(result.AuthorizationRequiredElement as Hl7.Fhir.Model.FhirBoolean, reader, outcome, locationPath + ".authorizationRequired"); // 150
							break;
						case "authorizationSupporting":
							var newItem_authorizationSupporting = new Hl7.Fhir.Model.CodeableConcept();
							await ParseAsync(newItem_authorizationSupporting, reader, outcome, locationPath + ".authorizationSupporting["+result.AuthorizationSupporting.Count+"]"); // 160
							result.AuthorizationSupporting.Add(newItem_authorizationSupporting);
							break;
						case "authorizationUrl":
							result.AuthorizationUrlElement = new Hl7.Fhir.Model.FhirUri();
							await ParseAsync(result.AuthorizationUrlElement as Hl7.Fhir.Model.FhirUri, reader, outcome, locationPath + ".authorizationUrl"); // 170
							break;
						default:
							// Property not found
							await HandlePropertyNotFoundAsync(reader, outcome, locationPath + "." + reader.Name);
							break;
					}
				}
				else if (reader.NodeType == XmlNodeType.EndElement || reader.IsStartElement() && reader.IsEmptyElement)
				{
					break;
				}
			}
		}
	}
}