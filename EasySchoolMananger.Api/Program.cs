using EasySchoolManager.Application.Services;
using EasySchoolManager.Infra;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Discord;
using System;

var builder = WebApplication.CreateBuilder(args);

#region Logger e configurações

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Verbose()
    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Warning)
    .WriteTo.File("logs/log-.txt",rollingInterval: RollingInterval.Day, retainedFileCountLimit: 30)
    .WriteTo.Discord(1447780256001036399, "CZhpqqig64-n8i5mfP1bxC2CtZEPp4y3IVoCF1wetHKQoZwDQVgp7_YLBceKHzL_qzb0", restrictedToMinimumLevel: LogEventLevel.Error)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true; 
    options.LowercaseQueryStrings = true;
});

builder.Services.AddDbContext<DataBaseContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection"));
});

#endregion

#region Dependencies injection

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddDbContext<DataBaseContext>();

#endregion

#region Swagger OpenAPI

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Environment

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

#endregion