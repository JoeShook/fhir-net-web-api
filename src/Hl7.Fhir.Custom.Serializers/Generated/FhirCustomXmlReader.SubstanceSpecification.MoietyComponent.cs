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
		public void Parse(Hl7.Fhir.Model.SubstanceSpecification.MoietyComponent result, XmlReader reader, OperationOutcome outcome, string locationPath)
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
						case "role":
							result.Role = new Hl7.Fhir.Model.CodeableConcept();
							Parse(result.Role as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".role"); // 40
							break;
						case "identifier":
							result.Identifier = new Hl7.Fhir.Model.Identifier();
							Parse(result.Identifier as Hl7.Fhir.Model.Identifier, reader, outcome, locationPath + ".identifier"); // 50
							break;
						case "name":
							result.NameElement = new Hl7.Fhir.Model.FhirString();
							Parse(result.NameElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".name"); // 60
							break;
						case "stereochemistry":
							result.Stereochemistry = new Hl7.Fhir.Model.CodeableConcept();
							Parse(result.Stereochemistry as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".stereochemistry"); // 70
							break;
						case "opticalActivity":
							result.OpticalActivity = new Hl7.Fhir.Model.CodeableConcept();
							Parse(result.OpticalActivity as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".opticalActivity"); // 80
							break;
						case "molecularFormula":
							result.MolecularFormulaElement = new Hl7.Fhir.Model.FhirString();
							Parse(result.MolecularFormulaElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".molecularFormula"); // 90
							break;
						case "amountQuantity":
							result.Amount = new Hl7.Fhir.Model.Quantity();
							Parse(result.Amount as Hl7.Fhir.Model.Quantity, reader, outcome, locationPath + ".amount"); // 100
							break;
						case "amountString":
							result.Amount = new Hl7.Fhir.Model.FhirString();
							Parse(result.Amount as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".amount"); // 100
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

		public async System.Threading.Tasks.Task ParseAsync(Hl7.Fhir.Model.SubstanceSpecification.MoietyComponent result, XmlReader reader, OperationOutcome outcome, string locationPath)
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
						case "role":
							result.Role = new Hl7.Fhir.Model.CodeableConcept();
							await ParseAsync(result.Role as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".role"); // 40
							break;
						case "identifier":
							result.Identifier = new Hl7.Fhir.Model.Identifier();
							await ParseAsync(result.Identifier as Hl7.Fhir.Model.Identifier, reader, outcome, locationPath + ".identifier"); // 50
							break;
						case "name":
							result.NameElement = new Hl7.Fhir.Model.FhirString();
							await ParseAsync(result.NameElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".name"); // 60
							break;
						case "stereochemistry":
							result.Stereochemistry = new Hl7.Fhir.Model.CodeableConcept();
							await ParseAsync(result.Stereochemistry as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".stereochemistry"); // 70
							break;
						case "opticalActivity":
							result.OpticalActivity = new Hl7.Fhir.Model.CodeableConcept();
							await ParseAsync(result.OpticalActivity as Hl7.Fhir.Model.CodeableConcept, reader, outcome, locationPath + ".opticalActivity"); // 80
							break;
						case "molecularFormula":
							result.MolecularFormulaElement = new Hl7.Fhir.Model.FhirString();
							await ParseAsync(result.MolecularFormulaElement as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".molecularFormula"); // 90
							break;
						case "amountQuantity":
							result.Amount = new Hl7.Fhir.Model.Quantity();
							await ParseAsync(result.Amount as Hl7.Fhir.Model.Quantity, reader, outcome, locationPath + ".amount"); // 100
							break;
						case "amountString":
							result.Amount = new Hl7.Fhir.Model.FhirString();
							await ParseAsync(result.Amount as Hl7.Fhir.Model.FhirString, reader, outcome, locationPath + ".amount"); // 100
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