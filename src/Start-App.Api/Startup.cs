// Copyright (c) Trickyrat All Rights Reserved.
// Licensed under the MIT LICENSE.

using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Start_App.Data.Models;

namespace Start_App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
            .AddConsole();
        });

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHttpClient();

            services.AddScoped<Service.V1.IEmployeeRepository, Service.V1.EmployeeRepository>();
            services.AddScoped<Service.V2.IEmployeeRepository, Service.V2.EmployeeRepository>();
            services.AddScoped<Service.V1.IProductRepository, Service.V1.ProductRepository>();

            services.AddSwaggerDocument(document =>
            {
                document.DocumentName = "v1";
                document.ApiGroupNames = new string[] { "v1" };
                document.Title = "线上版本";
                document.UseControllerSummaryAsTagDescription = true;
            });
            services.AddSwaggerDocument(document =>
            {
                document.DocumentName = "v2";
                document.ApiGroupNames = new string[] { "v2" };
                document.Title = "测试版本";
                document.UseControllerSummaryAsTagDescription = true;
            });
            // api version control
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
                options.ReportApiVersions = true;
            })
            .AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; //"'v'major[.minor][-status]"
                options.SubstituteApiVersionInUrl = true;
            });


            // database context
            services.AddDbContext<AdventureWorks2017Context>(options =>
            {
                options.UseLoggerFactory(_loggerFactory)
                .UseSqlServer(Configuration.GetConnectionString("SqlServerString"));
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddControllers();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseOpenApi();
            app.UseSwaggerUi3();


            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
               endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id}");
            });

            //app.UseAuthorization();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
