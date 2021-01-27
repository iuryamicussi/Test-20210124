using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Thomson.Assessment.Infrastructure.DAL;
using Thomson.Assessment.Model;
using Thomson.Assessment.Model.Validators;

namespace Thomson.Assessment
{
    public static class ConfigureInjections
    {
        public static void ConfigureMyServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(opt => 
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            ConfigureSwagger(services);
            ConfigureDataBase(services, configuration);
            ConfigureDependencies(services);
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Thomson.Assessment", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        private static void ConfigureDataBase(IServiceCollection services, IConfiguration configuration)
        {
            string dbConnectionString = configuration.GetConnectionString("sqlServer");

            services.AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString));
        }

        private static void ConfigureDependencies(IServiceCollection services)
        {
            services.AddScoped<ICaseRepository, CaseSQLWithDapperRepository>();
        }
    }
}