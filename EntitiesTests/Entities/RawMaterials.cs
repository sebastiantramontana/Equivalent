using Skyrmium.Composed.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesTests.Entities
{
    public static class RawMaterials
    {
        public static readonly SingletonEntity<RawMaterial> Sugar = new SingletonEntity<RawMaterial>(() => GetInstance("Sugar", 100.0, Measures.PackUnit.Instance, 1.0));
        public static readonly SingletonEntity<RawMaterial> Tomato = new SingletonEntity<RawMaterial>(() => GetInstance("Tomato", 200.0, Measures.Kg.Instance, 20.0));
        public static readonly SingletonEntity<RawMaterial> Lettuce = new SingletonEntity<RawMaterial>(() => GetInstance("Lettuce", 400.0, Measures.Kg.Instance, 15.0));
        public static readonly SingletonEntity<RawMaterial> Oil = new SingletonEntity<RawMaterial>(() => GetInstance("Oil", 300.0, Measures.Lt.Instance, 25.0));
        public static readonly SingletonEntity<RawMaterial> Salt = new SingletonEntity<RawMaterial>(() => GetInstance("Salt", 300.0, Measures.Kg.Instance, 30.0));
        public static RawMaterial GetInstance(string name, double packingCost, Measure packingMeasure, double packingQuantity)
        {
            return new RawMaterial { Guid = Guid.NewGuid(), Name = name, PackingCost = packingCost, PackingMeasure = packingMeasure, PackingQuantity = packingQuantity };
        }
    }
}
