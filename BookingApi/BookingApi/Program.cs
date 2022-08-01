using Booking.PersistanceDB.Context;
using Booking.Services.Models;
using BookingApi.Infastructure.Extensions;
using BookingApi.Infastructure.MyMiddlewares;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.
ConfigurationManager Configuration = builder.Configuration;

//Serilog Configuration
var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

builder.Services.AddServices();
builder.Services.AddTokenAuthentication(Configuration);
builder.Services.Configure<JWTConfiguration>(Configuration.GetSection(nameof(JWTConfiguration)));

builder.Services.AddDbContext<BookingContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnections")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
