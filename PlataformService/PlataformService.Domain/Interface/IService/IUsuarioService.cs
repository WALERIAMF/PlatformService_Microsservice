using PlataformService.Domain.Dto;
using PlataformService.Domain.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IService
{
    public interface IUsuarioService
    {
        Task PostColaborador(UsuarioPostRequest request);
        Task PutColaborador(UsuarioPutRequest request);
        Task DesativarPermissao(Guid id);
        Task<List<UsuarioDto>> GetColaborador();
        Task<UsuarioDto> GetColaboradorById(string nome);
    }
}
