using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts;
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
   public abstract class RepositoryBase<TEntity, TDao> : IRepository<TEntity>
      where TEntity : class, IEntity
      where TDao : class, IDao
   {
      public RepositoryBase(IDataAccess dataAccess, IMapper<TEntity, TDao> mapper)
      {
         this.DataAccess = dataAccess;
         this.Mapper = mapper;
      }

      protected IDataAccess DataAccess { get; }
      protected IMapper<TEntity, TDao> Mapper { get; }

      public async Task<IEnumerable<TEntity>> GetAll()
      {
         var daos = await this.DataAccess
            .Query<TDao>()
            .ToListAsync();

         return this.Mapper.Map(daos);
      }

      public Task<TEntity> GetById(Guid id)
      {
         return GetEntity(d => d.Id == id);
      }

      public async Task<TEntity> Create(TEntity entity)
      {
         ValidateIdIsEmpty(entity);

         var dao = this.Mapper.Map(entity);
         dao.Id = Guid.NewGuid();

         dao = await ContinueCreate(dao);
         return this.Mapper.Map(dao);
      }

      public async Task<IEnumerable<TEntity>> Create(IEnumerable<TEntity> entities)
      {
         foreach (var entity in entities)
            ValidateIdIsEmpty(entity);

         var daos = this.Mapper.Map(entities)
            .Select(d => { d.Id = Guid.NewGuid(); return d; });

         daos = await ContinueCreate(daos);
         return this.Mapper.Map(daos);
      }

      public Task Update(TEntity entity)
      {
         ValidateIdIsNotEmpty(entity);

         var dao = this.Mapper.Map(entity);
         return ContinueUpdate(dao);
      }

      public Task Update(IEnumerable<TEntity> entities)
      {
         foreach (var entity in entities)
            ValidateIdIsNotEmpty(entity);

         var daos = this.Mapper.Map(entities);
         return ContinueUpdate(daos);
      }

      public Task Delete(Guid id)
      {
         ValidateIdIsNotEmpty(id);
         return ContinueDelete(id);
      }

      public Task Delete(IEnumerable<Guid> ids)
      {
         foreach (var id in ids)
            ValidateIdIsNotEmpty(id);

         return ContinueDelete(ids);
      }

      protected async Task<TEntity> GetEntity(Expression<Func<TDao, bool>> expressionCondition)
      {
         var dao = await this.DataAccess
           .Query<TDao>()
           .SingleOrDefaultAsync(expressionCondition)
           ?? throw new DataObjectNotFoundException();

         var entity = this.Mapper.Map(dao);
         return entity;
      }

      private void ValidateIdIsNotEmpty(TEntity entity)
      {
         if (entity.Id == Guid.Empty)
            throw new MissingEntityIdException(entity);
      }

      private void ValidateIdIsNotEmpty(Guid id)
      {
         if (id == Guid.Empty)
            throw new MissingIdException(id);
      }

      private void ValidateIdIsEmpty(TEntity entity)
      {
         if (entity.Id != default)
            throw new EntityAlreadyHasIdException(entity);
      }

      protected abstract Task<TDao> ContinueCreate(TDao dao);
      protected abstract Task<IEnumerable<TDao>> ContinueCreate(IEnumerable<TDao> daos);
      protected abstract Task ContinueUpdate(TDao dao);
      protected abstract Task ContinueUpdate(IEnumerable<TDao> daos);
      protected abstract Task ContinueDelete(Guid id);
      protected abstract Task ContinueDelete(IEnumerable<Guid> ids);
   }
}
