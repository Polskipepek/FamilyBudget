using Serilog;

var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{envName}.json", optional: true) // Load the environment-specific appsettings file
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .Build();

var _logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .Enrich.FromLogContext()
    .CreateLogger();

_logger.Information("Using environment:" + envName);

var host = CreateHostBuilder(args, config)
    .ConfigureLogging(logging => {
        logging.ClearProviders();
        logging.AddSerilog(_logger);
    })
    .UseSerilog(_logger)
    .Build();

host.Run();

IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>
   Host.CreateDefaultBuilder(args)
   .ConfigureAppConfiguration((hostingContext, config) => config.AddConfiguration(configuration))
       .ConfigureWebHostDefaults(webBuilder => {

           if (envName != "Development") {
               _logger.Information("WARNING! PRODUCTION ENVIRONMENT");
               webBuilder.UseKestrel((context, options) => {
                   var certificatePath = "Keys/FamilyBudget.API.pfx";

                   options.ListenAnyIP(443, listenOptions => {
                       listenOptions.UseHttps(certificatePath);
                   });
               });
           }

           webBuilder.UseStartup<Startup>();
           webBuilder.UseIISIntegration();
       });
