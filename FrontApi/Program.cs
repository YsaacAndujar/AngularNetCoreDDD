using Application.Services;
using FluentValidation.AspNetCore;
using System.Reflection;
using Infrastructure.Repositories;
using Infrastructure.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPaswword = Environment.GetEnvironmentVariable("DB_SA_PASWWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog = {dbName};User Id=sa; Password={dbPaswword};TrustServerCertificate=true";
var optionBuilder = new DbContextOptionsBuilder<CarsContext>();
optionBuilder.UseSqlServer(connectionString);
CarsContext carsContext = new CarsContext(optionBuilder.Options);
builder.Services.AddControllersWithViews()
    .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped(provider => new BrandService(new BrandRepository(carsContext)));
builder.Services.AddScoped(provider => new CarModelService(
        new CarModelRepository(carsContext)
        , new BrandRepository(carsContext)
    )
);
builder.Services.AddScoped(provider => new CarService(
        new CarModelRepository(carsContext)
        , new CarRepository(carsContext)
    )
);
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
