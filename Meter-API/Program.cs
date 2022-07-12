using Meter_API.Facade;
using Meter_API.Repositories;
using Meter_API.Repositories.Impl;
using Meter_API.Repositories.Interface;
using Meter_API.Services.Impl;
using Meter_API.Services.Interface;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//per request object
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IMeterFacade, MeterFacade>();
builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddScoped<IFacilitiesRepository, FacilitiesRepository>();
builder.Services.AddScoped<IBuildingsRepository, BuildingsRepository>();
builder.Services.AddScoped<IFloorsRepository, FloorsRepository>();
builder.Services.AddScoped<IZonesRepository, ZonesRepository>();
builder.Services.AddScoped<IMetersRepository,MetersRepository>();

// Connect to PostgreSQL Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MetersDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

app.MapControllers();

app.Run();

