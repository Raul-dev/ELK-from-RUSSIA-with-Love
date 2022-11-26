1) Added 
Install-Package Microsoft.EntityFrameworkCore.Tools
https://www.learnentityframeworkcore.com/configuration/data-annotation-attributes
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design

2)Enable-Migrations -EnableAutomaticMigrations -Force
Add-Migration InitialCreate
Update-Database
3) https://dev.to/timothymcgrath/logging-scaffold-for-net-core-serilog-3o91
 dotnet add package Serilog.Sinks.Console
 dotnet add package Serilog.Sinks.File
4) https://github.com/serilog/serilog/wiki/Configuration-Basics

5) https://nblumhardt.com/2021/06/customize-serilog-text-output/
          "outputTemplate": "{Timestamp:HH:mm:ss.fff} [{Level:u3}] [{SourceContext}] {Message}{NewLine}{Exception}",
https://stackoverflow.com/questions/66550450/how-to-use-expression-template-with-appsettings-in-serilog

6) dotnet add package Serilog.Sinks.Elasticsearch --version 8.4.1
Install-Package serilog.sinks.elasticsearch
https://github.com/serilog-contrib/serilog-sinks-elasticsearch

"formatter": "Serilog.Formatting.Json.JsonFormatter, Serilog"
docker logs --tail 50 --follow --timestamps 51479fcb93a7

not found Sample.CustomPolicy
      {
        "Name": "With",
        "Args": { "policy": "Sample.CustomPolicy, Sample" }
      },
    "Enrich": [ "FromLogContext", "PodName", "NodeName" ],
    "Destructure": [
      {
        "Name": "ToMaximumDepth",
        "Args": { "maximumDestructuringDepth": 4 }
      },
      {
        "Name": "ToMaximumStringLength",
        "Args": { "maximumStringLength": 100 }
      },
      {
        "Name": "ToMaximumCollectionCount",
        "Args": { "maximumCollectionCount": 10 }
      }
    ],
