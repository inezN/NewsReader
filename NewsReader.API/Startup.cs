using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using NewsReader.Application.DTOs;
using NewsReader.Application.services;
using NewsReader.Persistance;
using NewsReader.Application.Interfaces;
using NewsReader.Persistance.Repository;
using NewsReader.Persistance.Repository.Interfaces;
using NewsReader.Application;
using NewsReader.Application.Mapping;

namespace NewsReader.API
{
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
            services.AddControllers();
            services.AddHttpClient();

            services.AddDbContext<NewsReaderContext>(options => options.UseSqlServer(Configuration.GetConnectionString("NewsReaderContext")));

            services.AddTransient<INewsInitializeService, NewsInitializeService>();
            services.AddTransient<INewsApiService, NewsApiService>();
            services.AddTransient<IArticleEntitiesRepository, ArticleEntitiesRepository>();
            services.AddTransient<ISourceEntitiesRepository, SourceEntitiesRepository>();

            services.Configure<MySettings>(options => Configuration.GetSection("MySettings").Bind(options));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new NewsProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.ExceptionHandling();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
