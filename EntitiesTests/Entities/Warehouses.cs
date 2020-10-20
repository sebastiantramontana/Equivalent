using EntitiesTests.Mocks;
using Moq;
using Skyrmium.Composed.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesTests.Entities
{
    public static class Warehouses
    {
        public static Warehouse Warehouse1 { get => GetInstance("Warehouse 1"); }
        public static Warehouse Warehouse2 { get => GetInstance("Warehouse 2"); }
        public static Warehouse Warehouse3 { get => GetInstance("Warehouse 3"); }
        private static Warehouse GetInstance(string name)
        {
            return new Warehouse(SingletonMockeado<INotifier>.Instance)
            {
                Name = name,
                Description = name + " bla bla bla",
                CurrentStock = new List<IngredientStock>()
            };
        }
    }
}
