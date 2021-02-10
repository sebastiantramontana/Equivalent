using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class MeasureToMeasureDao : OwnedEntityToOwnedDaoBase<Measure, MeasureDao>
   {
      protected override void ContinueWithOwnedEntity(IMappingExpression<Measure, MeasureDao> mappingExpression)
      {
         mappingExpression.ForMember(d => d.FullName, c => c.MapFrom(e => e.FullName));
         mappingExpression.ForMember(d => d.ShortName, c => c.MapFrom(e => e.ShortName));
      }

      protected override void ContinueWithOwnedDao(IMappingExpression<MeasureDao, Measure> mappingExpression)
      {
         mappingExpression.ForMember(e => e.FullName, c => c.MapFrom(d => d.FullName));
         mappingExpression.ForMember(e => e.ShortName, c => c.MapFrom(d => d.ShortName));
         //mappingExpression.ForMember(e => e.Equivalences, c => c.Ignore());
      }
   }
}
