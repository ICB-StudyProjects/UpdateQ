namespace UpdateQ.Api
{
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using NLog.Extensions.Logging;
    using UpdateQ.Api.Configuration;
    using UpdateQ.Data.Infrastructure;
    using UpdateQ.Data.Repositories;
    using UpdateQ.Model.DTOs;
    using UpdateQ.Model.Entities;
    using UpdateQ.Service;
    using UpdateQ.Service.Interfaces;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => 
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    // TODO: Change to more secure one
                    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
            });

            services.AddMvcCore()
                .AddJsonFormatters()
                .AddJsonOptions(option =>
                {
                    option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInfoNodeService, InfoNodeService>();
            services.AddScoped<ITimeSeriesNodeService, TimeSeriesNodeService>();

            // TODO: Add assembly ref and register them from there
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInfoNodeRepository, InfoNodeRepository>();
            services.AddScoped<ITimeSeriesNodeRepository, TimeSeriesNodeRepository>();
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseCors("AllowAll");

            //AutoMapperConfiguration.Initialize(); // Need to be used instead of the Mapper class
            AutoMapperConf.RegisterMappings();

            app.UseMvc();
        }
    }
}
