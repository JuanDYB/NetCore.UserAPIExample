using InnoCV.DatabaseModel.Database;
using InnoCVUserAPI.CustomExceptionMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace InnoCVUserAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private string _appVersion;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this._appVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Enable model validation filter
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = false;
            });
            this.AddSwagger(services);
            this.AddDatabase(services);            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // global error handler
            app.UseMiddleware<ExceptionHandler>();

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"InnoCV User API V{this._appVersion}");
            });

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"InnoCV UserAPI {_appVersion}",
                    Version = _appVersion,
                    Description = "Simple User Api for InnoCV",
                    Contact = new OpenApiContact
                    {
                        Name = "Juan Díez-Yanguas Barber",
                        Email = String.Empty,
                        Url = new Uri("https://juandyb.com/"),
                    }
                });
            });
        }
       
        private void AddDatabase(IServiceCollection services)
        {
            services.AddTransient<InnoCVEntities>(DB => new InnoCVEntities(Configuration.GetConnectionString("InnoCVEntities")));
        }
    }
}
