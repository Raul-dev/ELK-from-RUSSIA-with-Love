FROM nginx:1.17.1-alpine
COPY nginx.base.conf /etc/nginx/nginx.conf

RUN mkdir -p /var/logs/
RUN apk update  && apk add --no-progess bash certbot openssl  

#RUN rm /var/cache/apk/* 
COPY nginx.conf /etc/nginx/nginx.conf

RUN mkdir -p /etc/nginx/ssl/localhost/ 

COPY ./cert/localhost.key /etc/nginx/ssl/localhost/privkey.pem
COPY ./cert/localhost.crt /etc/nginx/ssl/localhost/fullchain.pem
RUN ln -sf /etc/nginx/ssl/localhost /etc/nginx/ssl/latest

COPY security.conf /etc/nginx/security.conf


