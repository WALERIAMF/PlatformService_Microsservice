using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IRepository
{
    public interface IBaseRepository<MODEL> where MODEL : class
    {

        Task AddAsync(MODEL model);
        Task<MODEL> GetByIdAsync(Guid id);
        Task<MODEL> GetByNameAsync(string name);
        Task<IEnumerable<MODEL>> GetAllAsync();
        void Update(MODEL model);
        void Remove(MODEL model);
        Task<IEnumerable<MODEL>> GetWhereAsync(Expression<Func<MODEL, bool>> predicate);
        Task<int> CountAllAsync();
        Task<int> CountWhereAsync(Expression<Func<MODEL, bool>> predicate);
        Task<MODEL> FirstOrDefaultAsync(Expression<Func<MODEL, bool>> predicate);


    }
}