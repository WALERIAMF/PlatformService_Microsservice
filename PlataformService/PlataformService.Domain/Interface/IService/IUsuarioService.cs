using PlataformService.Domain.Dto;
using PlataformService.Domain.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IService
{
    public interface IUsuarioService
    {
        Task PostUsuarioAsync(UsuarioPostRequest request);
        Task PutUsuarioAsync(UsuarioPutRequest request);
        Task DesativarUsuarioAsync(Guid id);
        Task<List<UsuarioDto>> GetUsuarioAsync();
        Task<UsuarioDto> GetUsuarioByIdAsync(Guid id);
    }
}
