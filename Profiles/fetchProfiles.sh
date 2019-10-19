

until $(curl --output /dev/null --fail --silent http://hapi-fhir-jpaserver-start:8080/hapi-fhir-jpaserver/fhir/metadata); do
    printf '.'
    sleep 1
done

curl https://www.hl7.org/fhir/bodyweight.profile.json -o bodyweight.profile.json
curl https://www.hl7.org/fhir/bp.profile.json -o bp.profile.json
curl --silent --output /dev/null -X PUT -H "Content-Type: application/json" -d@bodyweight.profile.json http://hapi-fhir-jpaserver-start:8080/hapi-fhir-jpaserver/fhir/StructureDefinition?url=http://hl7.org/fhir/StructureDefinition/bodyweight
curl --silent --output /dev/null -X PUT -H "Content-Type: application/json" -d@bp.profile.json http://hapi-fhir-jpaserver-start:8080/hapi-fhir-jpaserver/fhir/StructureDefinition?url=http://hl7.org/fhir/StructureDefinition/bp
