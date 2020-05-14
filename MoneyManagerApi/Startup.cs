using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MoneyManagerApi.Data;
using MoneyManagerApi.Data.Repositories;
using MoneyManagerApi.Data.Repositories.Contracts;
using MoneyManagerApi.Mappers;
using MoneyManagerApi.Models;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenApiSecurityRequirement = NSwag.OpenApiSecurityRequirement;
using OpenApiSecurityScheme = NSwag.OpenApiSecurityScheme;

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
            var jwtSettings = new JwtSettings();
            Configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<TransactionContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("TransactionContext")));

            services.AddScoped<DataInitializer>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<TransactionMapper>();
            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "TransactionAPI";
                c.Version = "v1";
                c.Description = "The Transaction documentation description.";
                c.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "JWT Authorization header using the bearer scheme"
                });
                c.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));

            });
            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true
                    };
            });

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
            app.UseAuthentication();

            dataInitializer.InitializeData();

        }
    }
}
