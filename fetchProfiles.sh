curl https://www.hl7.org/fhir/bodyweight.profile.json -o bodyweight.profile.json
curl https://www.hl7.org/fhir/bp.profile.json -o bp.profile.json
curl -s -o /dev/null -w '%{response_code}' -X PUT -H "Content-Type: application/json" -d@bodyweight.profile.json http://localhost:8080/hapi-fhir-jpaserver/fhir/StructureDefinition?url=http://hl7.org/fhir/StructureDefinition/bodyweight
curl -s -o /dev/null -w '%{response_code}' -X PUT -H "Content-Type: application/json" -d@bp.profile.json http://localhost:8080/hapi-fhir-jpaserver/fhir/StructureDefinition?url=http://hl7.org/fhir/StructureDefinition/bp
