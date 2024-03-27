using JourneyMentor.AirportService.DataAccess;
using JourneyMentor.AirportService.Business;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using JourneyMentor.AirportService.Models.Config;
using JourneyMentor.AirportService.Business.Mapper;
using JourneyMentor.AirportService.Services;
using JourneyMentor.AirportService.ServiceClients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AviationStackOptions>(builder.Configuration.GetSection(AviationStackOptions.AviationStackSettings));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddAirportHandlersModule();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddHttpClient();

var connString = builder.Configuration.GetValue<string>("ConnectionStrings:JourneyDBConnection");
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseMySQL(connectionString: connString));

builder.Services.AddScoped<IAirportInterface, AirportInterface>();

var app = builder.Build();

app.UsePathBase("/airportservice");
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
