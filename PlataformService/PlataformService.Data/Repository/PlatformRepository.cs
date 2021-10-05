using PlataformService.Data.Context;
using PlataformService.Data.Entity;
using PlataformService.Domain.Interface.IRepository;
using PlataformService.Domain.Model;

namespace PlataformService.Data.Repository
{
    public class PlatformRepository : BaseRepository<PlatformModel, PlatformEntity>, IPlatformRepository
    {
        public PlatformRepository(AppDbContext context) : base(context)
        {
        }

    }
}
