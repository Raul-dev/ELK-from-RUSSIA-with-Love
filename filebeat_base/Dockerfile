# From base OS image
# docker build -t filebeat-alpine
#docker build -t filebeat-alpine . --progress plain
FROM alpine:latest

ENV FILEBEAT_VERSION=8.0.0

COPY filebeat.yml /
RUN apk add --update-cache curl bash libc6-compat && \
    rm -rf /var/cache/apk/* 
	
#Заблокировано, файл надо качать через прокси
#RUN curl https://artifacts.elastic.co/downloads/beats/filebeat/filebeat-8.0.0-linux-x86_64.tar.gz -o /filebeat.tar.gz 
COPY filebeat-8.0.0-linux-x86_64.tar.gz filebeat.tar.gz

RUN tar xzvf filebeat.tar.gz 
RUN rm filebeat.tar.gz 
RUN	mv filebeat-8.0.0-linux-x86_64 filebeat
RUN ls filebeat
#    mv filebeat-${FILEBEAT_VERSION}-linux-x86_64 filebeat

RUN cd filebeat && \
    cp filebeat /usr/bin && \
    rm -rf /filebeat/filebeat.yml && \
    cp /filebeat.yml /filebeat/ 

RUN ls -ltr /filebeat && \
    cat /filebeat/filebeat.yml

VOLUME /filebeat/data

COPY filebeat.yml /usr/share/filebeat/filebeat.yml
#RUN chown -R root /usr/share/filebeat/
#RUN chmod -R go-w /usr/share/filebeat/
RUN mkdir -p /src/logs/
WORKDIR /filebeat/
CMD ["./filebeat","-e","-c", "filebeat.yml"]
