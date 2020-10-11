using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PS.Template.AccessData;
using Microsoft.EntityFrameworkCore;
using PS.Template.Application.Services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.AccessData.Repositories;
using PS.Template.Domain.Interfaces.Service;
using PS.Template.Domain.Interfaces.Query;
using PS.Template.AccessData.Query;
using SqlKata.Compilers;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PS.Template.API
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
            services.AddMvc();

            var connectionString = Configuration.GetSection("ConnectionString").Value;

            //EF Core
            services.AddDbContext<BaseDbContext> (opcion => opcion.UseSqlServer(connectionString));

            //SQLKata
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

            services.AddTransient<IPaqueteRepository, PaqueteRepository>();
            services.AddTransient<IPaqueteService, PaqueteService>();
            services.AddTransient<IPaqueteQuery, PaqueteQuery>();

            services.AddTransient<ITipoPaqueteRepository, TipoPaqueteRepository>();
            services.AddTransient<ITipoPaqueteService, TipoPaqueteService>();
            services.AddTransient<ITipoPaqueteQuery, TipoPaqueteQuery>();

            services.AddTransient<ISucursalPorEnvioRepository, SucursalPorEnvioRepository>();
            services.AddTransient<ISucursalPorEnvioService, SucursalPorEnvioService>();
            services.AddTransient<ISucursalPorEnvioQuery, SucursalPorEnvioQuery>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MicroService APIs v1.0",
                    Description = "Test services"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Habilitar swagger
            app.UseSwagger();
            //indica la ruta para generar la configuración de swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api REST");
                c.RoutePrefix = string.Empty;
            });

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
