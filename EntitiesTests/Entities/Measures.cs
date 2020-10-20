using EntitiesTests.Mocks;
using Skyrmium.Composed.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntitiesTests.Entities
{
    public static class Measures
    {
        public static SingletonEntity<Measure> Unit = new SingletonEntity<Measure>(() => GetInstance("Unit", "u", true));
        public static SingletonEntity<Measure> PackUnit = new SingletonEntity<Measure>(() => GetInstance("Pack Unit", "pu", true));
        public static SingletonEntity<Measure> Kg = new SingletonEntity<Measure>(() => GetInstance("Kilogram", "kg", true));
        public static SingletonEntity<Measure> Lt = new SingletonEntity<Measure>(() => GetInstance("Litre", "L", true));
        public static SingletonEntity<Measure> Gr = new SingletonEntity<Measure>(() => GetInstance("Gram", "gr", true));
        public static SingletonEntity<Measure> Dash = new SingletonEntity<Measure>(() => GetInstance("Dash", "ds", false));
        public static SingletonEntity<Measure> Pinch = new SingletonEntity<Measure>(() => GetInstance("Pinch", "pnh", false));
        private static Measure GetInstance(string name, string symbol, bool isPrecise)
        {
            return new Measure(SingletonMockeado<INotifier>.Instance)
            {
                Name = name,
                Symbol = symbol,
                IsPrecise = isPrecise,
                Guid = Guid.NewGuid()
            };
        }
    }
}
