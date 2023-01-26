﻿using Microsoft.EntityFrameworkCore;
using Serilog;
using Timetables.Core.Configuration;
using Timetables.Data;

namespace Timetables.Application.Extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers()
               .AddNewtonsoftJson(x =>
                   x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public static void ConfigureSerilog(this IHostBuilder host)
        {
            host.UseSerilog((ctx, lc) => lc
                .WriteTo.Console());
        }

        public static void ConfigureResponseCaching(this IServiceCollection services) =>
            services.AddResponseCaching();


        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config, IWebHostEnvironment env)
        {
            services.AddDbContext<TimetableDbContext>(
                options =>
                {
                    options.UseSqlite(config.GetConnectionString("DefaultSQLiteConnection"), b =>
                        b.MigrationsAssembly("Timetables.Data"));
                    if (env.IsDevelopment())
                    {
                        options.EnableSensitiveDataLogging();
                    }
                });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperInitilizer));
        }
    }
}
