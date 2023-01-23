using Microsoft.EntityFrameworkCore;
using TimetablesProject.Data;
using TimetablesProject.Controllers;
using TimetablesProject.Configurations;
using TimetablesProject.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<TimetableDbContext>(
    options => {
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultSQLiteConnection"));
        options.EnableSensitiveDataLogging();
    });

builder.Services.AddAutoMapper(typeof(MapperInitilizer));

builder.Services.AddCors(o => {
    o.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

//app.GenerateSeedTimetableDataAsync().Wait();

app.Run();
