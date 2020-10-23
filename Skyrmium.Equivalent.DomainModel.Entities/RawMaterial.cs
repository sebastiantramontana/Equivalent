namespace Skyrmium.Equivalent.DomainModel.Entities
{
   public class RawMaterial : IngredientBase
   {
      public GenericMaterial GenericMaterial { get; set; }
      public Brand Brand { get; set; }
      public double PackingCost { get; set; }

      protected override double CalculateFractionCost(double factorQuantity)
      {
         return this.PackingCost * factorQuantity;
      }
   }
}
