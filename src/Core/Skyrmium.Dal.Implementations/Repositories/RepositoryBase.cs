using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Dal.Contracts.Exceptions;
using Skyrmium.Dal.Contracts.Localization;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Services.Contracts.Repositories;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Dal.Implementations.Repositories
{
   public abstract class RepositoryBase<TEntity, TDao> : IRepository<TEntity>
      where TEntity : class, IEntity
      where TDao : class, IDao
   {
      private readonly IRepositoryLocalizer _localizer;

      public RepositoryBase(IDataAccess dataAccess, IMapper<TEntity, TDao> mapper, IRepositoryLocalizer Localizer)
      {
         this.DataAccess = dataAccess;
         this.Mapper = mapper;
         _localizer = Localizer;
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
         return GetEntity(d => d.Id == id, _localizer.DataNotFound);
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
         RepositoryBase<TEntity, TDao>.ValidateIdIsNotEmpty(entity);

         var dao = this.Mapper.Map(entity);
         return ContinueUpdate(dao);
      }

      public Task Update(IEnumerable<TEntity> entities)
      {
         foreach (var entity in entities)
            RepositoryBase<TEntity, TDao>.ValidateIdIsNotEmpty(entity);

         var daos = this.Mapper.Map(entities);
         return ContinueUpdate(daos);
      }

      public Task Delete(Guid id)
      {
         RepositoryBase<TEntity, TDao>.ValidateIdIsNotEmpty(id);
         return ContinueDelete(id);
      }

      public Task Delete(IEnumerable<Guid> ids)
      {
         foreach (var id in ids)
            RepositoryBase<TEntity, TDao>.ValidateIdIsNotEmpty(id);

         return ContinueDelete(ids);
      }

      protected async Task<TEntity> GetEntity(Expression<Func<TDao, bool>> expressionCondition, string errorMessage)
      {
         var dao = await this.DataAccess
           .Query<TDao>()
           .SingleOrDefaultAsync(expressionCondition)
           ?? throw new DataObjectNotFoundException(errorMessage);

         var entity = this.Mapper.Map(dao);
         return entity;
      }

      private static void ValidateIdIsNotEmpty(TEntity entity)
      {
         if (entity.Id == Guid.Empty)
            throw new MissingIdForUpdateException();
      }

      private static void ValidateIdIsNotEmpty(Guid id)
      {
         if (id == Guid.Empty)
            throw new MissingIdForDeleteException();
      }

      private void ValidateIdIsEmpty(TEntity entity)
      {
         if (entity.Id != default)
            throw new EntityAlreadyExistsException(_localizer.EntityAlreadyExists);
      }

      protected abstract Task<TDao> ContinueCreate(TDao dao);
      protected abstract Task<IEnumerable<TDao>> ContinueCreate(IEnumerable<TDao> daos);
      protected abstract Task ContinueUpdate(TDao dao);
      protected abstract Task ContinueUpdate(IEnumerable<TDao> daos);
      protected abstract Task ContinueDelete(Guid id);
      protected abstract Task ContinueDelete(IEnumerable<Guid> ids);
   }
}
