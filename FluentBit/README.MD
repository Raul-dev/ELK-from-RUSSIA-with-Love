## fluentd, fluentbit, This containers don't work yet.

TODO:

https://kevcodez.de/posts/2019-08-10-fluent-bit-docker-logging-driver-elasticsearch/

```
docker-compose -f docker-compose.td.yaml up --force-recreate
docker-compose -f docker-compose.bit.yaml up --force-recreate
```


docker info --format '{{.LoggingDriver}}'

https://www.couchbase.com/blog/using-fluent-bit-for-log-forwarding-processing-with-couchbase-server/
mkdir -p /tmp/couchbase-logs
docker run --rm -d --name db -p 8091-8096:8091-8096 -p 11210-11211:11210-11211 -v /tmp/couchbase-logs/:/opt/couchbase/var/lib/couchbase/logs/ couchbase:6.6.2

docker run --rm -d --name logger -v /tmp/couchbase-logs/:/opt/couchbase/var/lib/couchbase/logs/:ro -e COUCHBASE_LOGS=/opt/couchbase/var/lib/couchbase/logs/ couchbase/fluent-bit:1.0.1

docker run --rm -d --name loki -p 3100:3100 grafana/loki:2.0.0 -config.file=/etc/loki/local-config.yaml
docker run --rm -d --name grafana -p 3000:3000 -e GF_SECURITY_ADMIN_PASSWORD=password grafana/grafana:7.5.2
docker inspect --format='{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' loki
172.17.0.4

https://medium.com/hepsiburadatech/fluent-logging-architecture-fluent-bit-fluentd-elasticsearch-ca4a898e28aa

https://docs.docker.com/config/containers/logging/fluentd/

docker run -it -p 24224:24224 -v D:\Work\ELK\ELK-from-RUSSIA-with-Love\FluentBit\fluentbit.test.config:/fluentd/etc/test.conf -e FLUENTD_CONF=test.conf fluent/fluentd:latest

docker-compose -f docker-compose.td.yaml up --force-recreate
Fixed Cannot start service ubuntu: failed to initialize logging driver: dial tcp 127.0.0.1:24224: connect: connection refused
C:\ProgramData\docker\config\daemon.json
 {
   "log-driver": "fluentd",
   "log-opts": {
     "fluentd-address": "fluentd:24224"
   }
 }

/etc/docker/daemon.json 

log-driver