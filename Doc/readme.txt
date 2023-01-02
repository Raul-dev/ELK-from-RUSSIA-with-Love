https://habr.com/ruru/post/671344/
raulamailru/filebeat-alpine

# Create logstash from source:
git clone https://github.com/elastic/logstash.git
logstash-8.5.3.zip
unzip logstash-8.5.3.zip
cd logstash-8.5.3
docker build -t raulamailru/logstash.8.5.3 . --progress plain
docker tag raulamailru/logstash.8.5.3:latest raulamailru/logstash:8.5.3
docker push raulamailru/logstash:8.5.3