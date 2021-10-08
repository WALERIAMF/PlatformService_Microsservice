using PlataformService.Domain.Model;
using PlataformService.Domain.Response;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IService
{
    public interface IServiceAutenticacao
    {
        Task<ResponseData<string>> LogarUsuario(UsuarioModel model);
    }
}
