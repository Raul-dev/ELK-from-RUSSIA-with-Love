
using Serilog;

using Serilog.Events;
using Serilog.Sinks.File;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

using System.Security.AccessControl;
using Serilog.Formatting.Json;

using Serilog.Context;
using Serilog.Core.Enrichers;

using System.Text.RegularExpressions;

namespace Api07
{
    internal static class LogContextProperties
    {
        public const string PodName = "PodName";
        public const string NodeName = "NodeName";
    }
    public static class LogCore
    {

        public static IHostBuilder UseLogging(this IHostBuilder hostBuilder)
        {
            Serilog.Debugging.SelfLog.Enable(Console.Error);

            hostBuilder.UseSerilog((ctx, options) =>
            {
                options.ReadFrom.Configuration(ctx.Configuration);
            });

            return hostBuilder;
        }

        public static IApplicationBuilder UseLoggingContext(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                List<PropertyEnricher> properties = new()
            {
                new PropertyEnricher(LogContextProperties.PodName, context.TraceIdentifier),
                new PropertyEnricher(LogContextProperties.NodeName, context.TraceIdentifier)
            };

                using (LogContext.Push(properties.ToArray()))
                {
                    await next();
                }
            });
        }

        public static string GetEnvironment()
        {
            // The environment variable is needed for some logging configuration.
            string env = "ASPNETCORE_ENVIRONMENT";
            var environment = System.Environment.GetEnvironmentVariable(env);
            if (environment == null)
            {
                throw new NullReferenceException($"{env} environment variable is not set.");
            }

            return environment;
        }

        private static LoggerConfiguration ConfigureDefaults(string environment)
        {
            // Use the appsettings.json configuration to override minimum levels and add any additional sinks.
            var config = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            return new LoggerConfiguration()
//                .MinimumLevel.Information()
//                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
//                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .ReadFrom.Configuration(config);
                
        }
        public static LoggerConfiguration ConfigureLoger()
        {
            return ConfigureDefaults(GetEnvironment());
        }
        public static WebApplicationBuilder LogStartUp(this WebApplicationBuilder builder)
        {
            string env = builder.Environment.EnvironmentName;

            Log.Logger.Information($"Environment ASPNETCORE_ENVIRONMENT: {env}");

            string connection = builder.Configuration.GetConnectionString("Api07Context");

            return builder;
        }


    }
}
