using EntitiesTests.Mocks;
using Skyrmium.Equivalent.DomainModel.Entities;
using System.Collections.Generic;

namespace EntitiesTests.Entities
{
   public static class Branches
   {
      public static Branch Branch1 { get => GetInstance("Branch 1"); }
      public static Branch Branch2 { get => GetInstance("Branch 2"); }
      public static Branch Branch3 { get => GetInstance("Branch 3"); }

      private static Branch GetInstance(string name)
      {
         return new Branch()
         {
            Name = name,
            Description = name + " bla bla bla",
            Movements = new List<Movement>()
         };
      }
   }
}
