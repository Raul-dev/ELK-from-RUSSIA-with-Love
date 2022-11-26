FROM docker.io/bitnami/logstash:8
# Add your logstash plugins setup here
# Example: RUN logstash-plugin install logstash-filter-json
RUN logstash-plugin install logstash-input-http

RUN cat /etc/os-release
RUN ls /usr/share
#RUN mkdir -p /usr/share/logstash/config
COPY ./config/logstash.yml /usr/share/logstash/config/logstash.yml:
COPY ./pipeline /usr/share/logstash/pipeline