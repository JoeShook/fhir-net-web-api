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
		public void Parse(Hl7.Fhir.Model.Immunization.ProtocolAppliedComponent result, XmlReader reader, OperationOutcome outcome, string locationPath)
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
						case "series":
							result.SeriesElement = new Hl7.Fhir.Model.FhirString();
							Parse(result.SeriesElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".series"); // 40
							break;
						case "authority":
							result.Authority = new Hl7.Fhir.Model.ResourceReference();
							Parse(result.Authority as Hl7.Fhir.Model.ResourceReference, reader, outcome, locationPath + ".authority"); // 50
							break;
						case "targetDisease":
							var newItem_targetDisease = new Hl7.Fhir.Model.CodeableConcept();
							Parse(newItem_targetDisease, reader, outcome, locationPath + ".targetDisease["+result.TargetDisease.Count+"]"); // 60
							result.TargetDisease.Add(newItem_targetDisease);
							break;
						case "doseNumberPositiveInt":
							result.DoseNumber = new Hl7.Fhir.Model.PositiveInt();
							Parse(result.DoseNumber as Hl7.Fhir.Model.PositiveInt, reader, outcome, locationPath + ".doseNumber"); // 70
							break;
						case "doseNumberString":
							result.DoseNumber = new Hl7.Fhir.Model.FhirString();
							Parse(result.DoseNumber as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".doseNumber"); // 70
							break;
						case "seriesDosesPositiveInt":
							result.SeriesDoses = new Hl7.Fhir.Model.PositiveInt();
							Parse(result.SeriesDoses as Hl7.Fhir.Model.PositiveInt, reader, outcome, locationPath + ".seriesDoses"); // 80
							break;
						case "seriesDosesString":
							result.SeriesDoses = new Hl7.Fhir.Model.FhirString();
							Parse(result.SeriesDoses as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".seriesDoses"); // 80
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

		public async System.Threading.Tasks.Task ParseAsync(Hl7.Fhir.Model.Immunization.ProtocolAppliedComponent result, XmlReader reader, OperationOutcome outcome, string locationPath)
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
						case "series":
							result.SeriesElement = new Hl7.Fhir.Model.FhirString();
							await ParseAsync(result.SeriesElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".series"); // 40
							break;
						case "authority":
							result.Authority = new Hl7.Fhir.Model.ResourceReference();
							await ParseAsync(result.Authority as Hl7.Fhir.Model.ResourceReference, reader, outcome, locationPath + ".authority"); // 50
							break;
						case "targetDisease":
							var newItem_targetDisease = new Hl7.Fhir.Model.CodeableConcept();
							await ParseAsync(newItem_targetDisease, reader, outcome, locationPath + ".targetDisease["+result.TargetDisease.Count+"]"); // 60
							result.TargetDisease.Add(newItem_targetDisease);
							break;
						case "doseNumberPositiveInt":
							result.DoseNumber = new Hl7.Fhir.Model.PositiveInt();
							await ParseAsync(result.DoseNumber as Hl7.Fhir.Model.PositiveInt, reader, outcome, locationPath + ".doseNumber"); // 70
							break;
						case "doseNumberString":
							result.DoseNumber = new Hl7.Fhir.Model.FhirString();
							await ParseAsync(result.DoseNumber as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".doseNumber"); // 70
							break;
						case "seriesDosesPositiveInt":
							result.SeriesDoses = new Hl7.Fhir.Model.PositiveInt();
							await ParseAsync(result.SeriesDoses as Hl7.Fhir.Model.PositiveInt, reader, outcome, locationPath + ".seriesDoses"); // 80
							break;
						case "seriesDosesString":
							result.SeriesDoses = new Hl7.Fhir.Model.FhirString();
							await ParseAsync(result.SeriesDoses as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".seriesDoses"); // 80
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