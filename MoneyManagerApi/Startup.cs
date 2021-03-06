﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyManagerApi.Data;
using MoneyManagerApi.Data.Repositories;
using MoneyManagerApi.Data.Repositories.Contracts;
using MoneyManagerApi.Mappers;

namespace MoneyManagerApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<TransactionContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("TransactionContext")));

            services.AddScoped<DataInitializer>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<TransactionMapper>();
            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "RecipeAPI";
                c.Version = "v1";
                c.Description = "The Transaction documentation description.";
            });
            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataInitializer dataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseCors("AllowAllOrigins");


            dataInitializer.InitializeData();

        }
    }
}
