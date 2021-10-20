using PlataformService.Domain.Dto;
using PlataformService.Domain.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IService
{
    public interface IGrupoPermissaoService
    {
        Task PostGrupoPermissaoAsync(GrupoPermissaoPostRequest request);
        Task PutGrupoPermissaoAsync(GrupoPermissaoPutRequest request);
        Task DesativarGrupoPermissaoAsync(Guid id);
        Task<List<GrupoPermissaoDto>> GetGrupoPermissaoAsync();
        Task<GrupoPermissaoDto> GetGrupoPermissaoByIdAsync(Guid id);
        Task<GrupoPermissaoDto> GetGrupoPermissaoByNameAsync(string name);
    }
}
