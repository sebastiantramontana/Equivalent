using Skyrmium.DomainModel.Entities.Contracts;
using System;

namespace Skyrmium.Equivalent.DomainModel.Entities
{
   public interface IIngredient : IDistributableEntity
   {
      string Name { get; set; }
      DateTime? ExpirationDate { get; set; }
      double PackingQuantity { get; set; }
      Measure PackingMeasure { get; set; }
      double CalculatePartialCost(Measure measure, double quantity);
   }
}
