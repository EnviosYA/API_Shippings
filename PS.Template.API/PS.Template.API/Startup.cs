using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PS.Template.AccessData;
using Microsoft.EntityFrameworkCore;
using PS.Template.Application.Services;
using Microsoft.OpenApi.Models;
using PS.Template.Domain.Interfaces.Repositories;
using PS.Template.AccessData.Repositories;
using PS.Template.Domain.Interfaces.Service;
using PS.Template.Domain.Interfaces.Query;
using PS.Template.AccessData.Query;
using SqlKata.Compilers;
using System.Data;
using Microsoft.Data.SqlClient;
using PS.Template.Domain.Interfaces.RequestApis;
using PS.Template.Application.RequestAPis;

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

            // Paquete
            services.AddTransient<IPaqueteRepository, PaqueteRepository>();
            services.AddTransient<IPaqueteService, PaqueteService>();
            services.AddTransient<IPaqueteQuery, PaqueteQuery>();

            // Tipo Paquete
            services.AddTransient<ITipoPaqueteRepository, TipoPaqueteRepository>();
            services.AddTransient<ITipoPaqueteService, TipoPaqueteService>();
            services.AddTransient<ITipoPaqueteQuery, TipoPaqueteQuery>();

            // Sucursal por Envío
            services.AddTransient<ISucursalPorEnvioRepository, SucursalPorEnvioRepository>();
            services.AddTransient<ISucursalPorEnvioService, SucursalPorEnvioService>();
            services.AddTransient<ISucursalPorEnvioQuery, SucursalPorEnvioQuery>();

            // Estado
            services.AddTransient<IEstadoRepository, EstadoRepository>();
            services.AddTransient<IEstadoService, EstadoService>();
            services.AddTransient<IEstadoQuery, EstadoQuery>();

            // Envio
            services.AddTransient<IEnvioRepository, EnvioRepository>();
            services.AddTransient<IEnvioService, EnvioService>();
            services.AddTransient<IEnvioQuery, EnvioQuery>();

            // Microservicios
            services.AddTransient<IGenerateRequest, GenerateRequest>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MicroService APIs v1.0",
                    Description = "Test services"
                });
            });

            services.AddCors(c => {
                c.AddPolicy("AllowOrigin", options => options
                                                            .AllowAnyOrigin()
                                                            .AllowAnyMethod()
                                                            .AllowAnyHeader());
            });

            services.AddHttpContextAccessor();
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

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
