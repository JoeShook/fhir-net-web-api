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
		public void Parse(Hl7.Fhir.Model.ImplementationGuide.DefinitionComponent result, XmlReader reader, OperationOutcome outcome, string locationPath)
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
						case "grouping":
							var newItem_grouping = new Hl7.Fhir.Model.ImplementationGuide.GroupingComponent();
							Parse(newItem_grouping, reader, outcome, locationPath + ".grouping["+result.Grouping.Count+"]"); // 40
							result.Grouping.Add(newItem_grouping);
							break;
						case "resource":
							var newItem_resource = new Hl7.Fhir.Model.ImplementationGuide.ResourceComponent();
							Parse(newItem_resource, reader, outcome, locationPath + ".resource["+result.Resource.Count+"]"); // 50
							result.Resource.Add(newItem_resource);
							break;
						case "page":
							result.Page = new Hl7.Fhir.Model.ImplementationGuide.PageComponent();
							Parse(result.Page as Hl7.Fhir.Model.ImplementationGuide.PageComponent, reader, outcome, locationPath + ".page"); // 60
							break;
						case "parameter":
							var newItem_parameter = new Hl7.Fhir.Model.ImplementationGuide.ParameterComponent();
							Parse(newItem_parameter, reader, outcome, locationPath + ".parameter["+result.Parameter.Count+"]"); // 70
							result.Parameter.Add(newItem_parameter);
							break;
						case "template":
							var newItem_template = new Hl7.Fhir.Model.ImplementationGuide.TemplateComponent();
							Parse(newItem_template, reader, outcome, locationPath + ".template["+result.Template.Count+"]"); // 80
							result.Template.Add(newItem_template);
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

		public async System.Threading.Tasks.Task ParseAsync(Hl7.Fhir.Model.ImplementationGuide.DefinitionComponent result, XmlReader reader, OperationOutcome outcome, string locationPath)
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
						case "grouping":
							var newItem_grouping = new Hl7.Fhir.Model.ImplementationGuide.GroupingComponent();
							await ParseAsync(newItem_grouping, reader, outcome, locationPath + ".grouping["+result.Grouping.Count+"]"); // 40
							result.Grouping.Add(newItem_grouping);
							break;
						case "resource":
							var newItem_resource = new Hl7.Fhir.Model.ImplementationGuide.ResourceComponent();
							await ParseAsync(newItem_resource, reader, outcome, locationPath + ".resource["+result.Resource.Count+"]"); // 50
							result.Resource.Add(newItem_resource);
							break;
						case "page":
							result.Page = new Hl7.Fhir.Model.ImplementationGuide.PageComponent();
							await ParseAsync(result.Page as Hl7.Fhir.Model.ImplementationGuide.PageComponent, reader, outcome, locationPath + ".page"); // 60
							break;
						case "parameter":
							var newItem_parameter = new Hl7.Fhir.Model.ImplementationGuide.ParameterComponent();
							await ParseAsync(newItem_parameter, reader, outcome, locationPath + ".parameter["+result.Parameter.Count+"]"); // 70
							result.Parameter.Add(newItem_parameter);
							break;
						case "template":
							var newItem_template = new Hl7.Fhir.Model.ImplementationGuide.TemplateComponent();
							await ParseAsync(newItem_template, reader, outcome, locationPath + ".template["+result.Template.Count+"]"); // 80
							result.Template.Add(newItem_template);
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