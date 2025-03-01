using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace senai_lovePets_webApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                // Adiciona o servi�o dos Controllers
                .AddControllers()
                .AddNewtonsoftJson(options =>
                 {
                     // Ignora os loopings das consultas 
                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                     // Ignora os valores nulos ao fazer jun��es nas consultas
                     options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                 });



            // Adiciona o servi�o do Swagger
            // https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "lovePets.webApi", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services
                // Define a forma de autentica��o
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer"; // Define o esquema de autentica��o padrao
                    options.DefaultChallengeScheme = "JwtBearer";    // Esquema de valida��o padr�o
                })

                // Composi��o da valida��o
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Define que o issuer ser� validado
                        ValidateIssuer = true,

                        // Define que o audience ser� validado
                        ValidateAudience = true,

                        // Define que o tempo de vida ser� validado
                        ValidateLifetime = true,

                        // Forma de criptografia e a chave de autentica��o
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("lpets-chave-autenticacao")),

                        // Verifica o tempo de expira��o do token
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // Define o nome da issuer, de onde est� vindo
                        ValidIssuer = "lovePets.webApi",

                        // Define o nome da audience, e para onde est� indo
                        ValidAudience = "lovePets.webApi"
                    };
                });
        } // Fim de ConfigureServices



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "lovePets.webApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            // Habilita autentica��o
            app.UseAuthentication();

            // Habilita autoriza��o
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                // Define o mapeamento dos Controllers
                endpoints.MapControllers();
            });
        } // Fim de Configure
    }
}
