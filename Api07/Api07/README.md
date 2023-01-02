0) Add to host file for postgres connection from dev
YourLocalIP host.docker.internal
Example:
192.168.0.15 host.docker.internal

https://habr.com/ru/post/548998/
https://slurm.io/tpost/0d06xiobme-logirovanie-v-kubernetes-kak-sobirat-hra
https://docs.fluentbit.io/manual/installation/linux/ubuntu
apt-get update
apt-get -y install curl && apt-get -y install gpg

curl https://packages.fluentbit.io/fluentbit.key | gpg --dearmor > /usr/share/keyrings/fluentbit-keyring.gpg

echo "deb [signed-by=/usr/share/keyrings/fluentbit-keyring.gpg] https://packages.fluentbit.io/debian/bullseye bullseye main" >> /etc/apt/sources.list
apt-get -y update
apt-get -y upgrade
apt-get install -y fluent-bit


add-apt-repository 'deb [signed-by=/usr/share/keyrings/fluentbit-keyring.gpg] https://packages.fluentbit.io/debian/bullseye bullseye main'

apt-get update
apt-get upgrade
apt-get install -y fluent-bit

https://github.com/repeatedly/fluent-plugin-stdin
Setup
fluent bit -> Logstash
https://docs.fluentbit.io/tutorials/ship_to/logstash


https://medium.com/hepsiburadatech/fluent-logging-architecture-fluent-bit-fluentd-elasticsearch-ca4a898e28aa

https://www.elastic.co/guide/en/logstash/current/plugins-inputs-beats.html
input {
  beats {
    port => 5044
  }
}

output {
  elasticsearch {
    hosts => ["http://localhost:9200"]
    index => "%{[@metadata][beat]}-%{[@metadata][version]}" 
  }
}

https://medium.com/@matias.paulo84/net-core-serilog-elasticsearch-kibana-3bd080ff4c1e
