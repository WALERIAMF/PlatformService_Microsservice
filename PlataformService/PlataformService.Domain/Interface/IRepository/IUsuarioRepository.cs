using PlataformService.Domain.Model;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IRepository
{
    public interface IUsuarioRepository : IBaseRepository<UsuarioModel>
    {
        Task<bool> UsuarioEstaUsandoGrupoPermissao(string grupoPermissaoId);
        Task<bool> ExisteComLogin(string login);
        Task<UsuarioModel> BuscarPorLogin(string login);
        Task<UsuarioModel> BuscarPorColaboradorId(string id);
    }
}
