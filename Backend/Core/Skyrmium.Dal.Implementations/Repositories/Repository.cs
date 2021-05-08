using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Skyrmium.Dal.Implementations.Repositories
{
   public class Repository<TEntity, TDao> : IRepository<TEntity>
      where TEntity : class, IEntity
      where TDao : class, IDao
   {
      public Repository(DbContext dbContext, IMapper<TEntity, TDao> mapper)
      {
         this.DbContext = dbContext;
         this.Mapper = mapper;
      }

      protected DbContext DbContext { get; }
      protected IMapper<TEntity, TDao> Mapper { get; }

      public async Task<IEnumerable<TEntity>> GetAllAsync()
      {
         var daos = await this.DbContext.Set<TDao>().ToListAsync();
         return this.Mapper.Map(daos);
      }

      public Task<TEntity> GetByIdAsync(long id)
      {
         return GetSingleEntityAsync(d => d.Id == id);
      }

      public Task<TEntity> GetByDistributedIdAsync(Guid distributedId)
      {
         return GetSingleEntityAsync(d => d.DistributedId == distributedId);
      }

      public async Task<TEntity> Add(TEntity entity)
      {
         var dao = this.Mapper.Map(entity);

         TODO
         await this.DbContext.Set<TDao>().AddAsync(dao);
         await this.DbContext.SaveChangesAsync();

         entity = this.Mapper.Map(dao);
         return entity;
      }

      public void Update(TEntity entity)
      {
         var dao = this.Mapper.Map(entity);
         this.DbContext.Set<TDao>().Update(dao);
      }

      public void Remove(TEntity entity)
      {
         var dao = this.Mapper.Map(entity);
         this.DbContext.Set<TDao>().Remove(dao);
      }

      protected async Task<TEntity> GetSingleEntityAsync(Expression<Func<TDao, bool>> expressionCondition)
      {
         var dao = await this.DbContext
           .Set<TDao>()
           .SingleOrDefaultAsync(expressionCondition)
           ?? throw new DataObjectNotFoundException();

         var entity = this.Mapper.Map(dao);
         return entity;
      }
   }
}
