using Serilog;
using Timetables.Application.Extentions;
using Timetables.Core.AuthService;
using Timetables.Core.IRepository;
using Timetables.Core.IRepository.Base;
using Timetables.Core.Repository;
using Timetables.Core.Repository.Base;
using Timetables.Data;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureControllers();

builder.Services.ConfigureDbContext(builder.Configuration, builder.Environment);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();

builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.ConfigureAutoMapper();

builder.Host.ConfigureSerilog();

builder.Services.ConfigureSwagger();

builder.Services.ConfigureResponseCaching();

builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", corsPolicyBuilder =>
        corsPolicyBuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.Services.GenerateSeedTimetableDataAsync().Wait();

app.Run();



