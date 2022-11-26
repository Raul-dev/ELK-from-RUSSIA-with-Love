using Microsoft.EntityFrameworkCore;
using ProductApi;
using ProductApi.Data;
using Serilog;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = LogCore.ConfigureLoger()
        .CreateBootstrapLogger();

builder.Host.UseLogging();
builder.LogStartUp();
// Add services to the container.
builder.Services.AddDbContext<ProductApiContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ProductApiContext") ?? throw new InvalidOperationException("Connection string 'ProductApiContext' not found."),
    builder => builder.MigrationsAssembly(typeof(ProductApiContext).Assembly.FullName))
    );
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseLoggingContext();

try
{
    using (IServiceScope scope = app.Services.CreateScope())
    {
        scope.ServiceProvider.GetRequiredService<ProductApiContext>().Database.Migrate();
    }
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsProduction())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();

    //app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{
    Log.Error(ex.Message);
}
finally
{
    Log.CloseAndFlush();

}
