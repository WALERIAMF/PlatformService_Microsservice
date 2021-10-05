using Microsoft.EntityFrameworkCore;
using PlataformService.Domain.Interface.IRepository;
using System;

namespace PlataformService.Data.UnitOfWork
{
    public class UnitOfWork : IDisposable
{
   private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            this._dbContext = dbContext;

        }

        public bool Save()
        {
            bool isSuccess = _dbContext.SaveChanges() > 0;
            return isSuccess;
        }

        public void Dispose()
        {
            if (_dbContext == null) return;
            _dbContext.Dispose();
        }

        public readonly IPlatformRepository PlatformRepository;
    }
}
