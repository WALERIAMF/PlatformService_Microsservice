using PlataformService.Data.Context;
using PlataformService.Data.Entity;
using PlataformService.Domain.Interface.IRepository;
using PlataformService.Domain.Model;

namespace PlataformService.Data.Repository
{
    public class GrupoPermissaoRepository : BaseRepository<GrupoPermissaoModel, GrupoPermissaoEntity>, IGrupoPermissaoRepository
    {
        public GrupoPermissaoRepository(AppDbContext context) : base(context)
        {
        }

    }
}
