using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Dal.Contracts.Exceptions;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Services.Contracts.Repositories;
using Skyrmium.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Skyrmium.Dal.Implementations.Repositories
{
   public class Repository<TEntity, TDao> : IRepository<TEntity>
      where TEntity : class, IEntity
      where TDao : class, IDao, new()
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
         var daos = await this.DbContext
            .Set<TDao>()
            .ToListAsync();

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
         ValidateEntityToAdd(entity);

         var dao = this.Mapper.Map(entity);

         dao.DistributedId = Guid.NewGuid();
         dao = await FillChildrenIds(dao);

         var entry = await this.DbContext.AddAsync(dao);

         foreach (var nav in entry.References)
            nav.TargetEntry.State = EntityState.Unchanged;

         foreach (var col in entry.Collections)
            col.IsModified = false;

         await this.DbContext.SaveChangesAsync();

         return this.Mapper.Map(dao);
      }

      public async Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entities)
      {
         foreach (var entity in entities)
            ValidateEntityToAdd(entity);

         var daos = this.Mapper.Map(entities);
         await this.DbContext.AddRangeAsync(daos);

         return this.Mapper.Map(daos);
      }

      public void Update(TEntity entity)
      {
         ValidateEntityToModify(entity);

         this.DbContext.Update(this.DbContext.Set<TDao>().Single(d => d.DistributedId == entity.DistributedId));
      }

      public async Task Remove(Guid distributedId)
      {
         var id = await this.DbContext
                        .Set<TDao>()
                        .Where(d => d.DistributedId == distributedId)
                        .Select(d => d.Id)
                        .SingleAsync();

         this.DbContext.Remove(new TDao { Id = id });
         this.DbContext.SaveChanges();
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

      protected async Task<TRelatedDao> GetIdFromDistributedId<TRelatedDao>(TRelatedDao relatedDao)
         where TRelatedDao : class, IDao
      {
         var id = await this.DbContext
                        .Set<TRelatedDao>()
                        .Where(d => d.DistributedId == relatedDao.DistributedId)
                        .Select(d => d.Id)
                        .SingleAsync();

         relatedDao.Id = id;

         return relatedDao;
      }

      protected virtual Task<TDao> FillChildrenIds(TDao dao)
      {
         return Task.FromResult(dao);
      }

      private static void ValidateEntityToModify(TEntity entity)
      {
         if (entity.DistributedId == Guid.Empty)
            throw new MissingEntityIdException(entity);
      }

      private static void ValidateEntityToAdd(TEntity entity)
      {
         if (entity.Id != default || entity.DistributedId != Guid.Empty)
            throw new EntityAlreadyHasIdException(entity);
      }
   }
}
