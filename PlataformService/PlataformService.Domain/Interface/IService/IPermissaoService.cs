using PlataformService.Domain.Dto;
using PlataformService.Domain.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IService
{
    public interface IPermissaoService
    {
        Task PostColaborador(PermissaoPostRequest request);
        Task PutColaborador(PermissaoPutRequest request);
        Task DesativarPermissao(Guid id);
        Task<List<PermissaoDto>> GetColaborador();
        Task<PermissaoDto> GetColaboradorById(string nome);
    }
}
