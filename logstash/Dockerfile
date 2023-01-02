FROM logstash:8.5.3 

# raulamailru/logstash:8.5.3  
# Add your logstash plugins setup here
# Example: RUN logstash-plugin install logstash-filter-json
# RUN logstash-plugin install logstash-input-http
# RUN logstash-plugin install logstash-input-beats

RUN cat /etc/os-release
USER root
#for debug
#RUN apt-get update
#RUN apt-get install -y netcat
#RUN apt-get install -y net-tools
#RUN apt-get install telnet -y

#      - ./logstash/configs/:/usr/share/logstash/config:ro
#      - ./logstash/configs/pipelines.yml:/usr/share/logstash/config/pipelines.yml:ro
#      - ./logstash/pipelines:/usr/share/logstash/config/pipelines:ro      

COPY ./configs/logstash.yml /usr/share/logstash/config/logstash.yml
COPY ./configs/pipelines.yml /usr/share/logstash/config/pipelines.yml
COPY ./pipelines/logstash.conf /usr/share/logstash/config/pipelines/service_stamped_json_logs.conf


RUN chmod +rwx /usr/share/logstash/config/pipelines/service_stamped_json_logs.conf
RUN chown logstash /usr/share/logstash/config/pipelines/service_stamped_json_logs.conf


USER logstash
#RUN bin/logstash -f /usr/share/logstash/config/pipelines/service_stamped_json_logs.conf
