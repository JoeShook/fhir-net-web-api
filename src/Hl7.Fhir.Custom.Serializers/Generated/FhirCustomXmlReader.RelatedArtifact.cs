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
		public void Parse(Hl7.Fhir.Model.RelatedArtifact result, XmlReader reader, OperationOutcome outcome, string locationPath)
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
						case "type":
							result.TypeElement = new Hl7.Fhir.Model.Code<Hl7.Fhir.Model.RelatedArtifact.RelatedArtifactType>();
							Parse(result.TypeElement as Hl7.Fhir.Model.Code<Hl7.Fhir.Model.RelatedArtifact.RelatedArtifactType>, reader, outcome, locationPath + ".type"); // 30
							break;
						case "label":
							result.LabelElement = new Hl7.Fhir.Model.FhirString();
							Parse(result.LabelElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".label"); // 40
							break;
						case "display":
							result.DisplayElement = new Hl7.Fhir.Model.FhirString();
							Parse(result.DisplayElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".display"); // 50
							break;
						case "citation":
							result.Citation = new Hl7.Fhir.Model.Markdown();
							Parse(result.Citation as Hl7.Fhir.Model.Markdown, reader, outcome, locationPath + ".citation"); // 60
							break;
						case "url":
							result.UrlElement = new Hl7.Fhir.Model.FhirUrl();
							Parse(result.UrlElement as Hl7.Fhir.Model.FhirUrl, reader, outcome, locationPath + ".url"); // 70
							break;
						case "document":
							result.Document = new Hl7.Fhir.Model.Attachment();
							Parse(result.Document as Hl7.Fhir.Model.Attachment, reader, outcome, locationPath + ".document"); // 80
							break;
						case "resource":
							result.ResourceElement = new Hl7.Fhir.Model.Canonical();
							Parse(result.ResourceElement as Hl7.Fhir.Model.Canonical, reader, outcome, locationPath + ".resource"); // 90
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

		public async System.Threading.Tasks.Task ParseAsync(Hl7.Fhir.Model.RelatedArtifact result, XmlReader reader, OperationOutcome outcome, string locationPath)
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
						case "type":
							result.TypeElement = new Hl7.Fhir.Model.Code<Hl7.Fhir.Model.RelatedArtifact.RelatedArtifactType>();
							await ParseAsync(result.TypeElement as Hl7.Fhir.Model.Code<Hl7.Fhir.Model.RelatedArtifact.RelatedArtifactType>, reader, outcome, locationPath + ".type"); // 30
							break;
						case "label":
							result.LabelElement = new Hl7.Fhir.Model.FhirString();
							await ParseAsync(result.LabelElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".label"); // 40
							break;
						case "display":
							result.DisplayElement = new Hl7.Fhir.Model.FhirString();
							await ParseAsync(result.DisplayElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".display"); // 50
							break;
						case "citation":
							result.Citation = new Hl7.Fhir.Model.Markdown();
							await ParseAsync(result.Citation as Hl7.Fhir.Model.Markdown, reader, outcome, locationPath + ".citation"); // 60
							break;
						case "url":
							result.UrlElement = new Hl7.Fhir.Model.FhirUrl();
							await ParseAsync(result.UrlElement as Hl7.Fhir.Model.FhirUrl, reader, outcome, locationPath + ".url"); // 70
							break;
						case "document":
							result.Document = new Hl7.Fhir.Model.Attachment();
							await ParseAsync(result.Document as Hl7.Fhir.Model.Attachment, reader, outcome, locationPath + ".document"); // 80
							break;
						case "resource":
							result.ResourceElement = new Hl7.Fhir.Model.Canonical();
							await ParseAsync(result.ResourceElement as Hl7.Fhir.Model.Canonical, reader, outcome, locationPath + ".resource"); // 90
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