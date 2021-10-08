using PlataformService.Data.Context;
using PlataformService.Data.Entity;
using PlataformService.Domain.Interface.IRepository;
using PlataformService.Domain.Model;

namespace PlataformService.Data.Repository
{
    public class PermissaoRepository : BaseRepository<PermissaoModel, PermissaoEntity>, IPermissaoRepository
    {
        public PermissaoRepository(AppDbContext context) : base(context)
        {
        }

    }
}
