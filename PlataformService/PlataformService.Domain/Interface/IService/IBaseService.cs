using System.Collections.Generic;

namespace PlataformService.Domain.Interface.IService
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}