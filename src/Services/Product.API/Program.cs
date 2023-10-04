using Common.Logging;
using Product.API.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Information("Starting Product API up");

try
{
    builder.Host.UseSerilog(Serilogger.Configure);
    builder.Host.AddAppConfigurations();

    builder.Services.AddInfrastructure();

    var app = builder.Build();
    app.UseInfrastructure();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
