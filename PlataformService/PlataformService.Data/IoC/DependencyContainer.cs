using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlataformService.Data.Context;
using PlataformService.Data.Repository;
using PlataformService.Domain.Interface.IRepository;
using PlataformService.Domain.Interface.IService;
using PlataformService.Domain.Interface.UnitOfWork;
using PlataformService.Domain.Request;
using PlataformService.Service.Service;
using PlataformService.Service.Validators;
using System;

namespace PlataformService.Data.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString, IConfiguration Configuration)
        {
            //Context
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            //Services
            services.AddTransient<IColaboradorService, ColaboradorService>();
            services.AddTransient<IGrupoPermissaoService, GrupoPermissaoService>();
            services.AddTransient<IPermissaoService, PermissaoService>();
            services.AddTransient<IPlatformService, PlatformService>();
            services.AddTransient<IUsuarioService, UsuarioService>();


            //Repository
            services.AddTransient<IPlatformRepository, PlatformRepository>();
            services.AddTransient<IColaboradorRepository, ColaboradorRepository>();
            services.AddTransient<IGrupoPermissaoRepository, GrupoPermissaoRepository>();
            services.AddTransient<IPermissaoRepository, PermissaoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();


            // Unit Of Work
            services.AddTransient<IUnitOfWork, Repository.UnitOfWork.UnitOfWork>();

            services.AddTransient<IValidator<ColaboradorPutRequest>, ColaboradorPutRequestValidator>();
            services.AddTransient<IValidator<ColaboradorPostRequest>, ColaboradorPostRequestValidator>();

            //services.AddTransient<IValidator<GrupoPermissaoPutRequest>, GrupoPermissaoPutRequestValidator>();
            //services.AddTransient<IValidator<GrupoPermissaoPostRequest>, GrupoPermissaoPostRequestValidator>();


            //services.AddTransient<IValidator<PermissaoPutRequest>, PermissaoPutRequestValidator>();
            //services.AddTransient<IValidator<PermissaoPostRequest>, PermissaoPostRequestValidator>();

            services.AddTransient<IValidator<PlatformPutRequest>, PlatformPutRequestValidator>();
            services.AddTransient<IValidator<PlatformPostRequest>, PlatformPostRequestValidator>();

            //services.AddTransient<IValidator<UsuarioPutRequest>, UsuarioPutRequestValidator>();
            //services.AddTransient<IValidator<UsuarioPostRequest>, UsuarioPostRequestValidator>();

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }
    }
}
