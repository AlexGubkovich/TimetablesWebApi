using Microsoft.EntityFrameworkCore;
using TimetablesProject.Data;
using TimetablesProject.Controllers;
using TimetablesProject.Configurations;
using TimetablesProject.Middleware;
using TimetablesProject.IRepository;
using TimetablesProject.Repository;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web host");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers()
        .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console());

    builder.Services.AddDbContext<TimetableDbContext>(
        options => {
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultSQLiteConnection"));
            if (builder.Environment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();
            }
        });

    builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();

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

    //app.GenerateSeedTimetableDataAsync().Wait();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}


