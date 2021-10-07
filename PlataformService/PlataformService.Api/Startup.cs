using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PlataformService.Data.Context;
using PlataformService.Data.IoC;
using System;

namespace PlataformService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services, Configuration.GetConnectionString("PlatformsConn"), Configuration);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                     .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    .AllowCredentials()); // allow credentials

            });
            RegisterServices(services);

            services.AddControllers()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMvc(options =>
                        options.SuppressAsyncSuffixInActionNames = false);

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlataformService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                if (env.IsDevelopment())
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlataformService.Api v1"));

                if (env.IsStaging())
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "PlataformService.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (env.IsProduction() || env.IsStaging())
            {
                using (var service = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                                                            .CreateScope())
                {
                    using (var context = service.ServiceProvider.GetService<AppDbContext>())
                    {
                        context.Database.Migrate();
                    }
                }
            }
        }
    }
}
