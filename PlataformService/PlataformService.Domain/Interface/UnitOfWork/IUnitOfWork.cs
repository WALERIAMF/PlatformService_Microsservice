using PlataformService.Domain.Interface.IRepository;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.UnitOfWork
{
    public interface IUnitOfWork
    {
        IColaboradorRepository ColaboradorRepository { get; }
        IGrupoPermissaoRepository GrupoPermissaoRepository { get; }
        IPermissaoRepository PermissaoRepository { get; }
        IPlatformRepository PlatformRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }


        int Commit();
        Task<int> CommitAsync();

    }
}