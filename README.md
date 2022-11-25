# ELK-from-RUSSIA-with-Love
To get started, download the file filebeat-8.0.0-linux-x86_64.tar.gz using a proxy 
and place it in folder filebeat.

```
docker-compose -f docker-compose.elk.yml build --progress plain
docker-compose -f docker-compose.elk.yml up --no-color --force-recreate
```