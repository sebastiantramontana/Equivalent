namespace Skyrmium.Equivalent.Measurement.Dal.Daos
{
   public class OrderedMeasureEquivalenceDao
   {
      public int Order { get; set; }
      public MeasureEquivalenceDao MeasureEquivalence { get; set; } = new MeasureEquivalenceDao();
   }
}
