using PlataformService.Data.Context;
using PlataformService.Domain.Interface.IRepository;
using PlataformService.Domain.Model;

namespace PlataformService.Data.Repository
{
    public class ColaboradorRepository : BaseRepository<ColaboradorModel, ColaboradorEntity>, IColaboradorRepository
    {
        public ColaboradorRepository(AppDbContext context) : base(context) { }

    }
}
