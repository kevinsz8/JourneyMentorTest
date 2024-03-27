using JourneyMentor.FlightService.DataAccess;
using JourneyMentor.FlightService.Business;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using JourneyMentor.FlightService.Business.Mapper;
using JourneyMentor.FlightService.Models.Config;
using JourneyMentor.FlightService.ServiceClients;
using JourneyMentor.FlightService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AviationStackOptions>(builder.Configuration.GetSection(AviationStackOptions.AviationStackSettings));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddFlightHandlersModule();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddHttpClient();

var connString = builder.Configuration.GetValue<string>("ConnectionStrings:JourneyDBConnection");
builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseMySQL(connectionString: connString));

builder.Services.AddScoped<IFlightInterface, FlightInterface>();

var app = builder.Build();

app.UsePathBase("/flightservice");
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
