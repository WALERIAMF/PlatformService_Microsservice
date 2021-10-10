using PlataformService.Domain.Dto;
using PlataformService.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IService
{
    public interface IGrupoPermissaoService
    {
        Task PostColaborador(GrupoPermissaoPostRequest request);
        Task PutColaborador(GrupoPermissaoPutRequest request);
        Task DesativarPermissao(Guid id);
        Task<List<GrupoPermissaoDto>> GetColaborador();
        Task<GrupoPermissaoDto> GetColaboradorById(string nome);
    }
}
