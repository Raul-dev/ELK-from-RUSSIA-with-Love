
using Serilog;
using Serilog.Context;
using Serilog.Core.Enrichers;
using System.Text.RegularExpressions;


namespace ProductApi
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

            var cfg = new LoggerConfiguration()
/*
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(config["ElasticConfiguration:Uri"]))
                {
                    AutoRegisterTemplate = true,
                    TypeName = null, Библиотека засерилога глючит, шлёт _type
                    IndexFormat = "logs-my-stream",
                    BatchAction = ElasticOpType.Create,
                    //IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower()}-{DateTime.UtcNow:yyyy-MM}"
                })
*/
                .ReadFrom.Configuration(config);

            
            //var t = cfg.WriteTo["Elasticsearch"].type;
            return cfg;
        }
        public static LoggerConfiguration ConfigureLoger()
        {
            return ConfigureDefaults(GetEnvironment());
        }
        public static WebApplicationBuilder LogStartUp(this WebApplicationBuilder builder)
        {
            string env = builder.Environment.EnvironmentName;

            Log.Logger.Debug($"Environment ASPNETCORE_ENVIRONMENT: {env}");

            if (!builder.Environment.IsProduction())
            {
                string connection = builder.Configuration.GetConnectionString("ProductApiContext");
                if (!string.IsNullOrEmpty(connection))
                {
                    string strPort = "";
                    Regex rx = new(@$"Host=([^;]*)");
                    Match match = rx.Matches(connection)[0];
                    Regex rxDatabase = new(@$"Database=([^;]*)");
                    Match matchDatabase = rxDatabase.Matches(connection)[0];
                    Regex rxPort = new(@$"Port=([^;]*)");
                    Match matchPort = rxPort.Matches(connection)[0];
                    if (match.Groups.Count == 0)
                        Log.Logger.Debug("DB Host not found.");
                    if (matchDatabase.Groups.Count == 0)
                        Log.Logger.Debug("Database not found.");
                    if (matchPort.Groups.Count != 0)
                        strPort =", " + matchPort.Groups[0].Value;
                    if (match.Groups.Count != 0 && matchDatabase.Groups.Count != 0)
                        Log.Logger.Debug("Postgres DB setup: {0}, {1}{2}.", match.Groups[0].Value, matchDatabase.Groups[0].Value, strPort);
                }
            }

            return builder;
        }


    }
}
