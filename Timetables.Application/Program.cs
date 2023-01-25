﻿using Serilog;
using Timetables.Application.Extentions;
using Timetables.Core.IRepository;
using Timetables.Core.IRepository.Base;
using Timetables.Core.Repository;
using Timetables.Core.Repository.Base;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureControllers();

builder.Services.ConfigureDbContext(builder.Configuration, builder.Environment);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();

builder.Services.ConfigureAutoMapper();

builder.Host.ConfigureSerilog();

builder.Services.ConfigureSwagger();

builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

//app.Services.GenerateSeedTimetableDataAsync().Wait();

app.Run();


