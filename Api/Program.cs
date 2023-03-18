using Application.Services;
using FluentValidation.AspNetCore;
using System.Reflection;
using Infrastructure.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPaswword = Environment.GetEnvironmentVariable("DB_SA_PASWWORD");
var connectionString = $"Data Source=DESKTOP-PMHSDT1\\SQLEXPRESS;Initial Catalog = Cars;;TrustServerCertificate=true;Integrated Security=true;";
var optionBuilder = new DbContextOptionsBuilder<CarsContext>();
optionBuilder.UseSqlServer(connectionString);
CarsContext brandContext = new CarsContext(optionBuilder.Options);
CarsContext carmodelContext = new CarsContext(optionBuilder.Options);
CarsContext carContext = new CarsContext(optionBuilder.Options);
builder.Services.AddControllersWithViews()
    .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped(provider => new BrandService(new BrandRepository(brandContext)));
builder.Services.AddScoped(provider => new CarModelService(
        new CarModelRepository(carmodelContext)
        , new BrandRepository(carmodelContext)
    )
);
builder.Services.AddScoped(provider => new CarService(
        new CarModelRepository(carContext)
        , new CarRepository(carContext)
    )
);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(p => p.AddPolicy("corsapp", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
