```
docker-compose down
docker-compose build --progress plain --no-cache
docker-compose up --no-color --force-recreate
```

https://localhost
https://localhost/apitest/swagger

docker build -t nginxbase -f Dockerfile.base .
docker build -t nginxtest .
docker run --name nginxtestssl -d -p 8081:443 -p 8080:80 --rm nginxtest 
docker stop nginxtestssl
Invoke-WebRequest -URI http://localhost
Invoke-WebRequest -URI https://localhost/wagger


Generate localhost sertificate
```
./buildcrt.ps1
```

#generate cert using localhost.conf cd cert
openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout localhost.key -out localhost.crt -config localhost.conf
#openssl req -x509 -nodes -newkey rsa:4096 -keyout /etc/nginx/ssl/example.net/privkey.pem -out /etc/nginx/ssl/example.net/fullchain.#pem    -subj "/C=/ST=/L=/O=/CN=example.net" \

#convert cert to pfx using 
openssl pkcs12 -export -out localhost.pfx -inkey localhost.key -in localhost.crt

#(optionally) verify cert using 
openssl verify -CAfile localhost.crt localhost.crt 
which should yield localhost.crt: OK

How do I manually install the Securly SSL certificate on Windows
https://support.securly.com/hc/en-us/articles/360026808753-How-do-I-manually-install-the-Securly-SSL-certificate-on-Windows


Fixed chrome
chrome://flags/#allow-insecure-localhost

Microsoft
https://learn.microsoft.com/en-us/aspnet/core/security/docker-https?view=aspnetcore-7.0

https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-dev-certs
dotnet dev-certs https -ep ${env:USERPROFILE}\.aspnet\https\aspnetapp.pfx
dotnet dev-certs https --trust
dotnet dev-certs https --clean

dotnet dev-certs https -ep ./https/aspnetapp.pfx -p password

https://meikle.io/opensource/development-ssl-dotnetcore-docker.html

~\AppData\Roaming\ASP.NET\Https
~AppData\Roaming\Microsoft\UserSecrets

https://meikle.io/opensource/development-ssl-dotnetcore-docker.html
https://www.howtouselinux.com/post/exploring-unable-to-get-local-issuer-certificate

https://yetanotherchris.dev/net-core/converting-pfx-to-pem-in-dotnet-core/