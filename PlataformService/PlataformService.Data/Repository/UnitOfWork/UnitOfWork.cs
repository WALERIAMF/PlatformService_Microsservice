using Microsoft.EntityFrameworkCore;
using PlataformService.Data.Context;
using PlataformService.Domain.Interface.IRepository;
using PlataformService.Domain.Interface.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;

namespace PlataformService.Data.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private IPlatformRepository _platformRepository;
        public IPlatformRepository PlatformRepository => _platformRepository ?? (_platformRepository = new PlatformRepository(_context));


        public int Commit()
        {
            var n = _context.SaveChanges();
            DetachAllEntities();

            return n;
        }

        public async Task<int> CommitAsync()
        {
            var n = await _context.SaveChangesAsync();
            DetachAllEntities();

            return n;
        }

        private void DetachAllEntities()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Unchanged)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
