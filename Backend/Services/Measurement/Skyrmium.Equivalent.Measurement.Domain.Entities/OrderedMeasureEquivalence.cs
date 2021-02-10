namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class OrderedMeasureEquivalence
   {
      public OrderedMeasureEquivalence(int order, MeasureEquivalence measureEquivalence)
      {
         this.Order = order;
         this.MeasureEquivalence = measureEquivalence;
      }

      public int Order { get; }
      public MeasureEquivalence MeasureEquivalence { get; }
   }
}
