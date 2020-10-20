using Skyrmium.Composed.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using EntitiesTests.Entities;
using EntitiesTests.Mocks;
using Moq;

namespace EntitiesTests
{
    public class BranchTest
    {
        public BranchTest()
        {
            SetEquivalences();
        }

        private void SetEquivalences()
        {
            var equivalences = new List<MeasureEquivalence>
            {
                new MeasureEquivalence { Ingredient = RawMaterials.Sugar.Instance, From = Measures.Unit.Instance, To = Measures.Kg.Instance, Factor = 2.0 },
                new MeasureEquivalence { Ingredient = RawMaterials.Sugar.Instance, From = Measures.PackUnit.Instance, To = Measures.Unit.Instance, Factor = 20.0 },
                new MeasureEquivalence { Ingredient = RawMaterials.Sugar.Instance, From = Measures.PackUnit.Instance, To = Measures.Kg.Instance, Factor = 40.0 }
            };

            Measures.PackUnit.Instance.Equivalences = equivalences;
            Measures.Unit.Instance.Equivalences = equivalences;
            Measures.Kg.Instance.Equivalences = equivalences;
        }

        [Fact]
        public void AddIngredientToEmptyStockTest()
        {
            var branch = Branches.Branch1;
            branch.Warehouse = Warehouses.Warehouse1;

            //test
            branch.AddIngredientToStock(RawMaterials.Sugar.Instance, Measures.Unit.Instance, 3, MovementReason.Buy);
            branch.AddIngredientToStock(RawMaterials.Sugar.Instance, Measures.Kg.Instance, 2, "Something");

            //assert
            Assert.True(branch.Movements.Count() == 2, "Count debe ser igual a 2");
            Assert.True(branch.Movements.Count(m => m.Ingredient == RawMaterials.Sugar.Instance && m.Quantity == 3 && m.Measure == Measures.Unit.Instance && m.Reason == MovementReason.Buy && m.DateTime != DateTime.MaxValue) == 1);
            Assert.True(branch.Movements.Count(m => m.Ingredient == RawMaterials.Sugar.Instance && m.Quantity == 2 && m.Measure == Measures.Kg.Instance && m.Reason == MovementReason.Another && m.AnotherReasonDescription == "Something" && m.DateTime != DateTime.MaxValue) == 1);

            Assert.True(branch.Warehouse.CurrentStock.Count(s => s.Ingredient == RawMaterials.Sugar.Instance && s.Quantity == 0.2) == 1);
        }

        [Fact]
        public void AddIngredientToPartialStockTest()
        {
            var branch = Branches.Branch1;
            branch.Warehouse = Warehouses.Warehouse1;

            branch.Warehouse.CurrentStock.Add(new IngredientStock { Ingredient = RawMaterials.Tomato.Instance, Quantity = 9.0 });
            branch.Warehouse.CurrentStock.Add(new IngredientStock { Ingredient = RawMaterials.Lettuce.Instance, Quantity = 3.0 });

            //test
            branch.AddIngredientToStock(RawMaterials.Sugar.Instance, Measures.Unit.Instance, 3.0, MovementReason.Buy);
            branch.AddIngredientToStock(RawMaterials.Tomato.Instance, Measures.Kg.Instance, 12.0, MovementReason.Buy);
            branch.AddIngredientToStock(RawMaterials.Lettuce.Instance, Measures.Kg.Instance, 6.0, "Something");

            //assert
            Assert.True(branch.Movements.Count() == 3, "Count debe ser igual a 3");
            Assert.True(branch.Movements.Count(m => m.Ingredient == RawMaterials.Sugar.Instance && m.Quantity == 3.0 && m.Measure == Measures.Unit.Instance && m.Reason == MovementReason.Buy && m.DateTime != DateTime.MaxValue) == 1);
            Assert.True(branch.Movements.Count(m => m.Ingredient == RawMaterials.Tomato.Instance && m.Quantity == 12.0 && m.Measure == Measures.Kg.Instance && m.Reason == MovementReason.Buy && m.DateTime != DateTime.MaxValue) == 1);
            Assert.True(branch.Movements.Count(m => m.Ingredient == RawMaterials.Lettuce.Instance && m.Quantity == 6.0 && m.Measure == Measures.Kg.Instance && m.Reason == MovementReason.Another && m.AnotherReasonDescription == "Something" && m.DateTime != DateTime.MaxValue) == 1);

            Assert.True(branch.Warehouse.CurrentStock.Count(s => s.Ingredient == RawMaterials.Sugar.Instance && Math.Round(s.Quantity, 2) == 0.15) == 1, "Sugar");
            Assert.True(branch.Warehouse.CurrentStock.Count(s => s.Ingredient == RawMaterials.Tomato.Instance && s.Quantity == 21.0) == 1, "Tomato");
            Assert.True(branch.Warehouse.CurrentStock.Count(s => s.Ingredient == RawMaterials.Lettuce.Instance && s.Quantity == 9.0) == 1, "Lettuce");
        }

        [Fact]
        public void SubstractIngredientFromEmptyStockTest()
        {
            var branch = Branches.Branch1;
            branch.Warehouse = Warehouses.Warehouse1;

            //test
            branch.SubstractIngredientFromStock(RawMaterials.Sugar.Instance, Measures.Unit.Instance, 3, MovementReason.Buy);
            branch.SubstractIngredientFromStock(RawMaterials.Sugar.Instance, Measures.Unit.Instance, 7, MovementReason.Buy);

            SingletonMockeado<INotifier>.Mock.Verify(m => m.Notify(It.IsAny<string>(), It.IsAny<string>(), Severity.Warning), Times.Exactly(2), "Dos notificaciones de Warning no fueron realizadas!");
            Assert.True(branch.Movements.Count() == 2, "Count debe ser igual a 2");
            Assert.True(branch.Warehouse.CurrentStock.Count(s => s.Ingredient == RawMaterials.Sugar.Instance && Math.Round(s.Quantity, 2) == -0.5) == 1, "Sugar");
        }

        [Fact]
        public void SubstractIngredientFromPartialStockTest()
        {
            var branch = Branches.Branch1;
            branch.Warehouse = Warehouses.Warehouse1;

            branch.AddIngredientToStock(RawMaterials.Sugar.Instance, Measures.Kg.Instance, 6.0, MovementReason.Buy);

            //test
            branch.SubstractIngredientFromStock(RawMaterials.Sugar.Instance, Measures.Kg.Instance, 2.0, MovementReason.Buy);

            Assert.True(branch.Movements.Count() == 2, "Count debe ser igual a 2");
            Assert.True(branch.Warehouse.CurrentStock.Count(s => s.Ingredient == RawMaterials.Sugar.Instance && Math.Round(s.Quantity, 2) == 0.1) == 1, "Sugar");
        }

        [Fact]
        public void GetMovements1DayToBackTest()
        {
            var branch = Branches.Branch1;
            branch.Warehouse = Warehouses.Warehouse1;

            branch.AddIngredientToStock(RawMaterials.Sugar.Instance, Measures.Kg.Instance, 6.0, MovementReason.Buy);
            branch.SubstractIngredientFromStock(RawMaterials.Sugar.Instance, Measures.Kg.Instance, 2.0, MovementReason.Buy);

            var movs = branch.GetMovements(1);

            Assert.True(movs.Count() == 2);
            Assert.True(movs.All(m => m.Reason == MovementReason.Buy));
        }

        [Fact]
        public void GetMovementsEmptyAnotherReasonTest()
        {
            SingletonMockeado<INotifier>.Init(); //revisar diseño!

            var branch = Branches.Branch1;
            branch.Warehouse = Warehouses.Warehouse1;

            branch.AddIngredientToStock(RawMaterials.Sugar.Instance, Measures.Kg.Instance, 6.0, string.Empty);
            branch.SubstractIngredientFromStock(RawMaterials.Sugar.Instance, Measures.Kg.Instance, 2.0, MovementReason.Buy);

            var movs = branch.GetMovements(1);

            SingletonMockeado<INotifier>.Mock.Verify(m => m.Notify(It.IsAny<string>(), It.IsAny<string>(), Severity.Error), Times.Once, "Debe notificar, como error, un intento de movimiento con 'otra razón' vacía!");
            Assert.True(movs.Count() == 1);
            Assert.True(movs.All(m => m.Reason == MovementReason.Buy));
        }

        [Fact]
        public void GetMovementsNullAnotherReasonTest()
        {
            SingletonMockeado<INotifier>.Init(); //revisar diseño!

            var branch = Branches.Branch1;
            branch.Warehouse = Warehouses.Warehouse1;

            branch.AddIngredientToStock(RawMaterials.Sugar.Instance, Measures.Kg.Instance, 6.0, null);
            branch.SubstractIngredientFromStock(RawMaterials.Sugar.Instance, Measures.Kg.Instance, 2.0, MovementReason.Buy);

            var movs = branch.GetMovements(1);

            SingletonMockeado<INotifier>.Mock.Verify(m => m.Notify(It.IsAny<string>(), It.IsAny<string>(), Severity.Error), Times.Once, "Debe notificar, como error, un intento de movimiento con 'otra razón' vacía!");
            Assert.True(movs.Count() == 1);
            Assert.True(movs.All(m => m.Reason == MovementReason.Buy));
        }
    }
}
