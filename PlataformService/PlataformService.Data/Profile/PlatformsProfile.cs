using PlataformService.Data.Entity;
using PlataformService.Domain.Dto;
using PlataformService.Domain.Model;
using PlataformService.Domain.Request;

namespace PlataformService.Data.Profile
{
    public class PlatformsProfile : AutoMapper.Profile
    {
        public PlatformsProfile()
        {

            CreateMap<ColaboradorEntity, ColaboradorModel>().ReverseMap();
            CreateMap<GrupoPermissaoEntity, GrupoPermissaoModel>().ReverseMap();
            CreateMap<PermissaoEntity, PermissaoModel>().ReverseMap();
            CreateMap<PlatformEntity, PlatformModel>().ReverseMap();
            CreateMap<UsuarioEntity, UsuarioModel>().ReverseMap();

            CreateMap<ColaboradorPostRequest, ColaboradorModel>().ReverseMap();
            CreateMap<ColaboradorPutRequest, ColaboradorModel>().ReverseMap();
            CreateMap<PlatformPostRequest, PlatformModel>().ReverseMap();
            CreateMap<PlatformPutRequest, PlatformModel>().ReverseMap();

            CreateMap<ColaboradorDto, ColaboradorModel>().ReverseMap();
            CreateMap<PlatformDto, PlatformModel>().ReverseMap();


        }
    }
}