using Skyrmium.Dal.Implementations.EntityMapping;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Dal.EntityMapping
{
   public class MeasureToMeasureDao : OwnedEntityToDaoBase<Measure, MeasureDao>
   {
      protected override MeasureDao ContinueOwnedEntityToDao(Measure entity, MeasureDao dao)
      {
         dao.FullName = entity.FullName;
         dao.ShortName = entity.ShortName;

         return dao;
      }

      public override Measure Map(MeasureDao obj)
      {
         return new Measure(obj.Id, obj.OwnedBy, obj.FullName, obj.ShortName);
      }
   }
}
