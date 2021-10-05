using PlataformService.Domain.Interface.IRepository;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPlatformRepository PlatformRepository { get; }

        int Commit();
        Task<int> CommitAsync();

    }
}