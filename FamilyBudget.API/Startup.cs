namespace FamilyBudget.API;
public class Startup {
    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services) {

        services.AddDbContext<FamilyBudgetContext>(options => {
            options.UseNpgsql(Configuration.GetConnectionString("FamilyBudgetContext") ?? throw new InvalidOperationException("Connection string 'FamilyBudgetContext' not found."));
            options.EnableSensitiveDataLogging();
        });

        // Add services to the container.
        services.AddAuthorizationBuilder()
            .AddPolicy("greetings", policy => policy.RequireRole("admin"));

        services.AddAuthentication();
        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Serilog.ILogger logger, FamilyBudgetContext dbContext) {
        logger.Information("TEST123");

        CreateDbIfNotExists(dbContext);

        // Configure the HTTP request pipeline.
        //  if (env.IsDevelopment()) {
        app.UseSwagger();
        app.UseSwaggerUI();
        //   }

        app.UseHttpsRedirection();

        app.UseCors();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });
    }

    private static void CreateDbIfNotExists(FamilyBudgetContext context) {
        context.Database.EnsureCreated();
    }
}
