using Skyrmium.Equivalent.DomainModel.Entities;
using System.Collections.Generic;

namespace EntitiesTests.Entities
{
   public static class Warehouses
   {
      public static Warehouse Warehouse1 { get => GetInstance("Warehouse 1"); }
      public static Warehouse Warehouse2 { get => GetInstance("Warehouse 2"); }
      public static Warehouse Warehouse3 { get => GetInstance("Warehouse 3"); }
      private static Warehouse GetInstance(string name)
      {
         return new Warehouse()
         {
            Name = name,
            Description = name + " bla bla bla",
            CurrentStock = new List<IngredientStock>()
         };
      }
   }
}
