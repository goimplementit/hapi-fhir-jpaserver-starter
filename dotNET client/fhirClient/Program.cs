using System.Collections.Generic;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

namespace fhirClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var observation = new Observation
            {
                Meta = new Meta
                {
                    Profile = new string[] { "http://hl7.org/fhir/StructureDefinition/vitalsigns" }
                }


            };
            observation.Identifier = new List<Identifier>{
                new Identifier("urn:ietf:rfc:3986","urn:uuid:" + System.Guid.NewGuid())
            };
            observation.Status = ObservationStatus.Final;
            observation.Category = new List<CodeableConcept> {new CodeableConcept("http://terminology.hl7.org/CodeSystem/observation-category", "vital-signs", "Vital Signs")};
            observation.Code = new CodeableConcept("http://loinc.org", "85354-9","Blood pressure panel with all children optional", "Blood pressure systolic & diastolic");
            observation.Subject = new ResourceReference("Patient/example");
            observation.Effective = new FhirDateTime();
            observation.Performer = new List<ResourceReference> { new ResourceReference("Practitioner/example") };
            observation.Interpretation = new List<CodeableConcept> { new CodeableConcept("http://terminology.hl7.org/CodeSystem/v3-ObservationInterpretation", "L", "low", "Below low normal") };
            observation.BodySite = new CodeableConcept("http://snomed.info/sct", "368209003", "Right arm", "Right arm");

            
            var systolicCodings = new List<Coding>() { new Coding("http://loinc.org", "8480-6", "Systolic blood pressure"), new Coding("http://loinc.org", "271649006", "Systolic blood pressure") };
            var systolicComponent = new Observation.ComponentComponent();
            systolicComponent.Code = new CodeableConcept{Coding = systolicCodings};
            systolicComponent.Value = new Quantity(107, "mmHg");
           systolicComponent.Interpretation = new List<CodeableConcept> {new CodeableConcept("http://terminology.hl7.org/CodeSystem/v3-ObservationInterpretation", "N","display", "Normal")};

           var diastolicCodings = new List<Coding>() { new Coding("http://loinc.org", "8462-4", "Diastolic blood pressure") };
           var diastolicComponent = new Observation.ComponentComponent();
           diastolicComponent.Code = new CodeableConcept{Coding = diastolicCodings};
           diastolicComponent.DataAbsentReason = new CodeableConcept("http://terminology.hl7.org/CodeSystem/data-absent-reason", "not-performed", "Not Performed");

           observation.Component =  new List<Observation.ComponentComponent>{systolicComponent ,diastolicComponent};

            new FhirClient("http://localhost:8080/hapi-fhir-jpaserver/fhir/")
                .Create<Observation>(observation);

        }
    }
}