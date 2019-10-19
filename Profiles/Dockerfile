FROM alpine:3.8

RUN apk add --no-cache curl

COPY fetchProfiles.sh .

ENTRYPOINT ["/bin/sh", "./fetchProfiles.sh"]