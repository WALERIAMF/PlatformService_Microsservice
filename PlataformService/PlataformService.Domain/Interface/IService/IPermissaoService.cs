using PlataformService.Domain.Dto;
using PlataformService.Domain.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IService
{
    public interface IPermissaoService
    {
        Task DesativarPermissaoAsync(Guid id);
        Task<List<PermissaoDto>> GetPermissaoAsync();
        Task<PermissaoDto> GetPermissaoByIdAsync(Guid id);
        Task PostPermissaoAsync(PermissaoPostRequest request);
        Task PutColaboradorAsync(PermissaoPutRequest request);
    }
}
