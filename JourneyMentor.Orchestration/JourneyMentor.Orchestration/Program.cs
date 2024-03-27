using System.Reflection;
using JourneyMentor.Orchestration.Business;
using JourneyMentor.Orchestration.Business.Mappers;
using JourneyMentor.Orchestration.Models;
using JourneyMentor.Orchestration.ServiceClients;
using JourneyMentor.Orchestration.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.UseUrls("http://0.0.0.0:8090");

builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ServiceConfigOptions>(builder.Configuration.GetSection(ServiceConfigOptions.MicroserviceUrls));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddOrchestrationHandlersModule();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<HttpService>();
builder.Services.AddScoped<IAirportInterface, AirportInterface>();

var app = builder.Build();

app.UsePathBase("/orchestration");
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("AllowAll"); 

app.UseAuthorization();

app.MapControllers();

app.Run();
