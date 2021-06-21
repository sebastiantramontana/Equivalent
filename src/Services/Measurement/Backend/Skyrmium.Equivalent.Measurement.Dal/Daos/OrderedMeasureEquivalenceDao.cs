using Skyrmium.Dal.Implementations.Daos;

namespace Skyrmium.Equivalent.Measurement.Dal.Daos
{
   public class OrderedMeasureEquivalenceDao : DaoBase
   {
      public int Order { get; set; }
      public MeasureEquivalenceDao MeasureEquivalence { get; set; } = new MeasureEquivalenceDao();
      public bool InvertEquivalence { get; set; }
      public ConversionDao Conversion { get; set; } = new ConversionDao();
   }
}
