using lending_skills_backend.DataAccess;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using lending_skills_backend.Validators;
using lending_skills_backend.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add CORS - исправленная версия
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Set port
builder.WebHost.UseUrls("http://*:80");

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Lending Skills API",
        Version = "v1",
        Description = "API для платформы Lending Skills"
    });
});

// Обновленная регистрация FluentValidation
builder.Services.AddControllers()
    .AddFluentValidation();

// Современный способ регистрации валидаторов
var validatorAssemblies = new[] { typeof(Program).Assembly };
builder.Services.AddValidatorsFromAssemblies(validatorAssemblies);

builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<ReviewsRepository>();
builder.Services.AddScoped<UsersRepository>();
builder.Services.AddScoped<ProgramsRepository>();
builder.Services.AddScoped<FormsRepository>();
builder.Services.AddScoped<ProfessorsRepository>();
builder.Services.AddScoped<BlocksRepository>();
builder.Services.AddScoped<SkillsRepository>();
builder.Services.AddScoped<TagsRepository>();
builder.Services.AddScoped<WorksRepository>();
builder.Services.AddScoped<TokensRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
    
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging()
               .EnableDetailedErrors();
    }
});

var app = builder.Build();

using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
await dbContext.Database.EnsureCreatedAsync();

// Включение Swagger в любом окружении (можно ограничить только Development)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lending Skills API V1");
    c.RoutePrefix = "swagger";
});

// Enable CORS с указанием политики
app.UseCors("AllowAll");

app.MapControllers();

// Add a simple health check endpoint
app.MapGet("/", () => "Backend server is running!");

app.Run();
