

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FamilyBudgetContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("FamilyBudgetContext") ?? throw new InvalidOperationException("Connection string 'FamilyBudgetContext' not found.")));

// Add services to the container.
builder.Services.AddAuthentication();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
