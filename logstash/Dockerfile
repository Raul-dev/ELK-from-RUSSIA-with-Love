FROM ubuntu 
#microdeb/bullseye
# Add your logstash plugins setup here
# Example: RUN logstash-plugin install logstash-filter-json
#RUN logstash-plugin install logstash-input-http
https://artifacts.elastic.co/downloads/logstash/logstash-8.5.2-amd64.deb

RUN echo $USER

RUN cat /etc/os-release
RUN ls /usr/share
RUN mkdir -p /src/logs
RUN mkdir -p /tmp
RUN ls /
#RUN apt-get install sudo

RUN mkdir -p /usr/share/logstash/config
#/opt/bitnami/logstash/pipeline/logstash.conf
RUN apt-get update
RUN apt-get install -y default-jre
RUN java -version
#RUN apt-get install -y wget
#RUN apt-get -y install curl && apt-get -y install gpg && apt-get -y install dpkg
#dpkg --get-selections
#RUN wget -qO - https://artifacts.elastic.co/GPG-KEY-elasticsearch | apt-key add -
#COPY GPG-KEY-elasticsearch /tmp/GPG-KEY-elasticsearch
#RUN cat /tmp/GPG-KEY-elasticsearch | apt-key add -
#RUN cat /etc/apt/sources.list
#RUN curl https://artifacts.elastic.co/GPG-KEY-elasticsearch | gpg --dearmor > /usr/share/keyrings/elasticsearch-keyring.gpg

#RUN curl -fsSL https://artifacts.elastic.co/GPG-KEY-elasticsearch | gpg --dearmor -o /usr/share/keyrings/elastic-8.x.gpg
#RUN echo "deb https://artifacts.elastic.co/packages/8.x/apt stable main" | tee -a /etc/apt/sources.list.d/elastic-8.x.list
#RUN cat /etc/apt/sources.list

#RUN echo "deb [signed-by=/usr/share/keyrings/elasticsearch-keyring.gpg] https://packages.fluentbit.io/debian/bullseye bullseye main" >> /etc/apt/sources.list
#deb [arch=amd64,arm64 signed-by=/usr/share/keyrings/elastic-7.x.gpg] https://artifacts.elastic.co/packages/7.x/apt stable main

#RUN apt-get -y update

#RUN apt-get install -y apt-transport-https
#RUN apt-get update
#RUN apt-get install -y logstash

RUN apt install -f google-chrome-stable_current_amd64.deb 

COPY ./config/logstash.yml /usr/share/logstash/config/logstash.yml:
COPY ./pipeline /usr/share/logstash/pipeline

#COPY ./config/logstash.yml /opt/bitnami/logstash/config/logstash.yml:
#COPY ./pipeline /opt/bitnami/logstash/pipeline
#CMD ["/opt/logstash/bin/logstash", "-f", "/usr/share/logstash/pipeline/logstash.conf", "-v", "--debug", "--verbose"]