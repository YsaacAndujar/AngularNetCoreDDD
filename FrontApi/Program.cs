using Application.Services;
using FluentValidation.AspNetCore;
using System.Reflection;
using Infrastructure.Repositories;
using Infrastructure.Contexts;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
CarsContext carsContext = new CarsContext();
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
