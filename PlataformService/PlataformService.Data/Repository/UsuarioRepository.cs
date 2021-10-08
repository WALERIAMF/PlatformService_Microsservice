using PlataformService.Data.Context;
using PlataformService.Data.Entity;
using PlataformService.Domain.Interface.IRepository;
using PlataformService.Domain.Model;

namespace PlataformService.Data.Repository
{
    public class UsuarioRepository : BaseRepository<UsuarioModel, UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

    }
}
