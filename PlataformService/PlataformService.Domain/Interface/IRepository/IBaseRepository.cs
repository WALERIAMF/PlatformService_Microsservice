using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlataformService.Domain.Interface.IRepository
{
    public interface IBaseRepository<MODEL> where MODEL : class
    {

        Task Add(MODEL model);
        Task<MODEL> GetById(Guid id);
        Task<IEnumerable<MODEL>> GetAll();
        void Update(MODEL model);
        void Remove(MODEL model);
        Task<MODEL> FirstOrDefault(Expression<Func<MODEL, bool>> predicate);
        Task<IEnumerable<MODEL>> GetWhere(Expression<Func<MODEL, bool>> predicate);
        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<MODEL, bool>> predicate);


    }
}