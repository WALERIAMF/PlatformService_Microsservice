using PlataformService.Data.Entity;
using PlataformService.Domain.Dto;
using PlataformService.Domain.Model;
using PlataformService.Domain.Request;

namespace PlataformService.Data.Profile
{
    public class PlatformServiceProfile : AutoMapper.Profile
    {
        public PlatformServiceProfile()
        {

            CreateMap<ColaboradorEntity, ColaboradorModel>().ReverseMap();
            CreateMap<ColaboradorPostRequest, ColaboradorModel>().ReverseMap();
            CreateMap<ColaboradorDto, ColaboradorModel>().ReverseMap();
            CreateMap<ColaboradorPutRequest, ColaboradorModel>().ReverseMap();

            CreateMap<GrupoPermissaoEntity, GrupoPermissaoModel>().ReverseMap();
            CreateMap<GrupoPermissaoDto, GrupoPermissaoModel>().ReverseMap();
            CreateMap<GrupoPermissaoPostRequest, GrupoPermissaoModel>().ReverseMap();
            CreateMap<GrupoPermissaoPutRequest, GrupoPermissaoModel>().ReverseMap();

            CreateMap<PermissaoEntity, PermissaoModel>().ReverseMap();
            CreateMap<PermissaoDto, PermissaoModel>().ReverseMap();
            CreateMap<PermissaoPostRequest, PermissaoModel>().ReverseMap();
            CreateMap<PermissaoPutRequest, PermissaoModel>().ReverseMap();

            CreateMap<PlatformEntity, PlatformModel>().ReverseMap();
            CreateMap<PlatformDto, PlatformModel>().ReverseMap();
            CreateMap<PlatformPostRequest, PlatformModel>().ReverseMap();
            CreateMap<PlatformPutRequest, PlatformModel>().ReverseMap();

            CreateMap<UsuarioEntity, UsuarioModel>().ReverseMap();
            CreateMap<UsuarioDto, UsuarioModel>().ReverseMap();
            CreateMap<UsuarioPostRequest, UsuarioModel>().ReverseMap(); 
            CreateMap<UsuarioPutRequest, UsuarioModel>().ReverseMap();

            CreateMap<PermissaoEntity, PermissaoModel>().ReverseMap();
            CreateMap<PermissaoDto, PermissaoModel>().ReverseMap();
            CreateMap<PermissaoPostRequest, PermissaoModel>().ReverseMap();
            CreateMap<PermissaoPutRequest, PermissaoModel>().ReverseMap();


        }
    }
}