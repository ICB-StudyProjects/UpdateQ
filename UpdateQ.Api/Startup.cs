namespace UpdateQ.Api
{
    using AutoMapper;
    using IdentityServer4.AccessTokenValidation;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using NLog.Extensions.Logging;
    using System.IdentityModel.Tokens.Jwt;
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
                    builder.WithOrigins("http://localhost:4200", "http://localhost:49342")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            services
                .AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters()
                .AddJsonOptions(option =>
                {
                    option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:52351/";
                    options.RequireHttpsMetadata = false; // TODO: Change to {true} if in production
                    options.ApiName = "updateq";
                });

            //TODO: Add TLS
            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            //    options.HttpsPort = 44370;
            //});

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

            app.UseAuthentication();

            // For TLS
            //app.UseHttpsRedirection();

            //AutoMapperConfiguration.Initialize(); // Need to be used instead of the Mapper class
            AutoMapperConf.RegisterMappings();

            app.UseMvc();
        }
    }
}
