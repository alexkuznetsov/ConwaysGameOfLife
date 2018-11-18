using System;
using GameOfLife.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        public void Case_FieldShouldBeInitializedWithSomeAliveCells()
        {
            var field = new Field();
            var cells = field.State;
            var alive = AliveCellFilter.Apply(cells);

            Assert.IsTrue(alive.Length > 0);
        }

        [TestMethod]
        public void Case_FindNeigboursForCellIn_0_0_ShouldReturnOneNeighbour()
        {
            var field = new Field();
            var neigboursCount = new AliveNeigboursCounter(field)
                .Count(0, 0);

            Assert.AreEqual(neigboursCount, 1);
        }

        [TestMethod]
        public void Case_FindNeigboursForCellIn_0_1_ShouldReturnTwoNeighbours()
        {
            var field = new Field();
            var neigboursCount = new AliveNeigboursCounter(field)
                .Count(0, 1);

            Assert.AreEqual(neigboursCount, 2);
        }

        [TestMethod]
        public void Case_FindNeigboursForCellIn_3_3_ShouldReturnFiveNeighbours()
        {
            var field = new Field();
            var neigboursCount = new AliveNeigboursCounter(field)
                .Count(2, 2);

            Assert.AreEqual(neigboursCount, 5);
        }

        [TestMethod]
        public void Case_FindNeigboursForCellIn_3_1_ShouldReturnThreeNeighbours()
        {
            var field = new Field();
            var neigboursCount = new AliveNeigboursCounter(field)
                .Count(1, 3);

            Assert.AreEqual(neigboursCount, 3);
        }
    }
}
