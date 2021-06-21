using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Contracts.Localization;
using Skyrmium.Dal.Implementations.Repositories;
using Skyrmium.Domain.Contracts.Exceptions;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Measure;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories;
using Skyrmium.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Dal.Repositories
{
   internal class MeasureRepository : OwnedRepositoryBase<Measure, MeasureDao>, IMeasureRepository
   {
      private readonly IMeasureLocalizer _measureLocalizer;

      public MeasureRepository(IDataAccess dataAccess, IMapper<Measure, MeasureDao> mapper, IMeasureLocalizer measureLocalizer, IRepositoryLocalizer repositoryLocalizer)
         : base(dataAccess, mapper, repositoryLocalizer)
      {
         _measureLocalizer = measureLocalizer;
      }

      protected override Task<MeasureDao> ContinueCreate(MeasureDao dao)
      {
         ValidateFullName(dao);

         return this.DataAccess.Create(dao);
      }

      protected override Task<IEnumerable<MeasureDao>> ContinueCreate(IEnumerable<MeasureDao> daos)
      {
         foreach (var dao in daos)
            ValidateFullName(dao);

         return this.DataAccess.Create(daos);
      }

      protected override Task ContinueUpdate(MeasureDao dao)
      {
         ValidateFullName(dao);

         return this.DataAccess.Update(dao);
      }

      protected override Task ContinueUpdate(IEnumerable<MeasureDao> daos)
      {
         foreach (var dao in daos)
            ValidateFullName(dao);

         return this.DataAccess.Update(daos);
      }

      protected override Task ContinueDelete(Guid id)
      {
         return this.DataAccess.Delete(new MeasureDao { Id = id });
      }

      protected override Task ContinueDelete(IEnumerable<Guid> ids)
      {
         return this.DataAccess.Delete(ids.Select(id => new MeasureDao { Id = id }));
      }

      private void ValidateFullName(MeasureDao dao)
      {
         if (string.IsNullOrEmpty(dao.FullName))
            throw new BusinessException(_measureLocalizer.InvalidMeasure, _measureLocalizer.EmptyFullName);
      }
   }
}
