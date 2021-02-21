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
		public void Parse(Hl7.Fhir.Model.EffectEvidenceSynthesis.ResultsByExposureComponent result, XmlReader reader, OperationOutcome outcome, string locationPath)
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
						case "description":
							result.DescriptionElement = new Hl7.Fhir.Model.FhirString();
							Parse(result.DescriptionElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".description"); // 40
							break;
						case "exposureState":
							result.ExposureState_Element = new Hl7.Fhir.Model.Code<Hl7.Fhir.Model.EffectEvidenceSynthesis.ExposureState>();
							Parse(result.ExposureState_Element as Hl7.Fhir.Model.Code<Hl7.Fhir.Model.EffectEvidenceSynthesis.ExposureState>, reader, outcome, locationPath + ".exposureState"); // 50
							break;
						case "variantState":
							result.VariantState = new Hl7.Fhir.Model.CodeableConcept();
							Parse(result.VariantState as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".variantState"); // 60
							break;
						case "riskEvidenceSynthesis":
							result.RiskEvidenceSynthesis = new Hl7.Fhir.Model.ResourceReference();
							Parse(result.RiskEvidenceSynthesis as Hl7.Fhir.Model.ResourceReference, reader, outcome, locationPath + ".riskEvidenceSynthesis"); // 70
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

		public async System.Threading.Tasks.Task ParseAsync(Hl7.Fhir.Model.EffectEvidenceSynthesis.ResultsByExposureComponent result, XmlReader reader, OperationOutcome outcome, string locationPath)
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
						case "description":
							result.DescriptionElement = new Hl7.Fhir.Model.FhirString();
							await ParseAsync(result.DescriptionElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".description"); // 40
							break;
						case "exposureState":
							result.ExposureState_Element = new Hl7.Fhir.Model.Code<Hl7.Fhir.Model.EffectEvidenceSynthesis.ExposureState>();
							await ParseAsync(result.ExposureState_Element as Hl7.Fhir.Model.Code<Hl7.Fhir.Model.EffectEvidenceSynthesis.ExposureState>, reader, outcome, locationPath + ".exposureState"); // 50
							break;
						case "variantState":
							result.VariantState = new Hl7.Fhir.Model.CodeableConcept();
							await ParseAsync(result.VariantState as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".variantState"); // 60
							break;
						case "riskEvidenceSynthesis":
							result.RiskEvidenceSynthesis = new Hl7.Fhir.Model.ResourceReference();
							await ParseAsync(result.RiskEvidenceSynthesis as Hl7.Fhir.Model.ResourceReference, reader, outcome, locationPath + ".riskEvidenceSynthesis"); // 70
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