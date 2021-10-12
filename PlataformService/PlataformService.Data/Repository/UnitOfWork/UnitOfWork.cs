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

        private IColaboradorRepository _colaboradorRepository;
        public IColaboradorRepository ColaboradorRepository => _colaboradorRepository ?? (_colaboradorRepository = new ColaboradorRepository(_context));

        private IGrupoPermissaoRepository _grupoPermissaoRepository;
        public IGrupoPermissaoRepository GrupoPermissaoRepository => _grupoPermissaoRepository ?? (_grupoPermissaoRepository = new GrupoPermissaoRepository(_context));

        private IPermissaoRepository _permissaoRepository;
        public IPermissaoRepository PermissaoRepository => _permissaoRepository ?? (_permissaoRepository = new PermissaoRepository(_context));

        private IUsuarioRepository _usuarioRepository;
        public IUsuarioRepository UsuarioRepository => _usuarioRepository ?? (_usuarioRepository = new UsuarioRepository(_context));

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
