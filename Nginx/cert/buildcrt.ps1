#openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout localhost.key -out localhost.crt -config localhost.conf -passout pass:
#dotnet dev-certs https -ep ./localhost.crt--trust --format PEM
dotnet dev-certs https --cleant
dotnet dev-certs https -ep ./localhost.crt -np --trust --format pem
#dotnet dev-certs https -ep ./localhost.pfx 

openssl pkcs12 -export -out localhost.pfx -inkey localhost.key -in localhost.crt -passout pass:
#openssl verify -CAfile localhost.crt localhost.crt 

#dotnet dev-certs https -ep ${env:USERPROFILE}\.aspnet\https\aspnetapp.pfx

Copy-Item  -Path ./localhost.pfx -Destination ..\Https\localhost.pfx  -Recurse -force

#Copy-Item  -Path ./localhost.pfx -Destination ${env:USERPROFILE}\.aspnet\https\aspnetapp.pfx  -Recurse -force
#Copy-Item  -Path ./localhost.pfx -Destination C:\Users\raul\AppData\Roaming\ASP.NET\Https\localhost.pfx  -Recurse -force
#dotnet dev-certs https --trust
#  openssl verify error 20 at 0 depth lookup: unable to get local issuer certificate for dotnet dev-certs

#https://www.fearofoblivion.com/setting-up-asp-net-dev-certs-for-both-wsl-and-windows