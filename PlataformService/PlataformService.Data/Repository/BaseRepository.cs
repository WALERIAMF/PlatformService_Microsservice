using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PlataformService.Data.Entity;
using PlataformService.Data.Profile;
using PlataformService.Domain.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlataformService.Data.Repository
{
    public class BaseRepository<MODEL, ENTITY> : IBaseRepository<MODEL>
    where MODEL : class
    where ENTITY : BaseEntity
    {
        private readonly DbContext _db;
        protected readonly IMapper _mapper;

        public BaseRepository(DbContext dbContext)
        {
            _db = dbContext;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(PlatformServiceProfile));
            });
            _mapper = config.CreateMapper();
        }
        public async Task AddAsync(MODEL model)
        {
            var entity = _mapper.Map<ENTITY>(model);

            await _db.Set<ENTITY>().AddAsync(entity);
        }
        public async Task<MODEL> GetByIdAsync(Guid id)
        {
            var entity = await _db.Set<ENTITY>().FindAsync(id);
            if (entity != null)
            {
                _db.Entry(entity).State = EntityState.Detached;
            }

            return _mapper.Map<MODEL>(entity);
        }
        public async Task<MODEL> GetByNameAsync(string name)
        {
            var entity = await _db.Set<ENTITY>().FindAsync(name);
            if (entity != null)
            {
                _db.Entry(entity).State = EntityState.Detached;
            }

            return _mapper.Map<MODEL>(entity);
        }
        public async Task<IEnumerable<MODEL>> GetAllAsync()
        {

            var entities = await _db.Set<ENTITY>().ToListAsync();

            return _mapper.Map<List<MODEL>>(entities);
        }
        public async Task<IEnumerable<MODEL>> GetWhereAsync(Expression<Func<MODEL, bool>> predicate)
        {
            var entities = await _db.Set<ENTITY>().ProjectTo<MODEL>(_mapper.ConfigurationProvider).AsNoTracking()
                .Where(predicate).AsNoTracking().ToListAsync();

            return entities;
        }
        public void Update(MODEL model)
        {
            var entity = _mapper.Map<ENTITY>(model);

            // In case AsNoTracking is used
            _db.Entry(entity).State = EntityState.Modified;
        }
        public void Remove(MODEL model)
        {
            var entity = _mapper.Map<ENTITY>(model);
            _db.Set<ENTITY>().Remove(entity);
        }
        public async Task<int> CountAllAsync()
        {
            return await _db.Set<ENTITY>().CountAsync();
        }
        public async Task<int> CountWhereAsync(Expression<Func<MODEL, bool>> predicate)
        {
            var where = _mapper.Map<Expression<Func<ENTITY, bool>>>(predicate);
            return await _db.Set<ENTITY>().CountAsync(where);
        }
        public async Task<MODEL> FirstOrDefaultAsync(Expression<Func<MODEL, bool>> predicate)
        {
            var model = await _db.Set<ENTITY>().ProjectTo<MODEL>(_mapper.ConfigurationProvider).AsNoTracking()
                .Where(predicate).AsNoTracking().FirstOrDefaultAsync();
            return model;
        }
    }
}