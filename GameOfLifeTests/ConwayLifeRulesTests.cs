using System;
using System.Linq;
using GameOfLife.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class ConwayLifeRulesTests
    {
        [TestMethod]
        public void Case_Cell_ChouldDeadThenLessThanTwoNeigbours()
        {
            var initialState = CellState.Alive;

            var state1 = LifeEngineRules.NextState(initialState, 1);
            var state2 = LifeEngineRules.NextState(initialState, 0);

            var expected = new[] { state1, state2 };
            var actual = new[] { CellState.Dead, CellState.Dead };

            Assert.IsTrue(Enumerable.SequenceEqual<CellState>(expected, actual));
        }


        [TestMethod]
        public void Case_Cell_ChouldBeAliveThenNeigboursCountBetweenTwoOrThree()
        {
            var initialState = CellState.Alive;

            var state1 = LifeEngineRules.NextState(initialState, 2);
            var state2 = LifeEngineRules.NextState(initialState, 3);

            var expected = new[] { state1, state2 };
            var actual = new[] { CellState.Alive, CellState.Alive };

            Assert.IsTrue(Enumerable.SequenceEqual<CellState>(expected, actual));
        }

        [TestMethod]
        public void Case_Cell_ChouldBeDeadThenNeigboursCountMoreThanThree()
        {
            var rand = new Random(System.DateTime.Now.Second);
            var initialState = CellState.Alive;

            var state1 = LifeEngineRules.NextState(initialState, rand.Next(4, int.MaxValue));
            var state2 = LifeEngineRules.NextState(initialState, rand.Next(4, int.MaxValue));

            var expected = new[] { state1, state2 };
            var actual = new[] { CellState.Dead, CellState.Dead };

            Assert.IsTrue(Enumerable.SequenceEqual<CellState>(expected, actual));
        }

        [TestMethod]
        public void Case_DeadCell_ChouldBeAlibeThenNeigboursCountEqualsThree()
        {
            var initialState = CellState.Dead;
            var state1 = LifeEngineRules.NextState(initialState, 3);

            Assert.AreEqual(state1, CellState.Alive);
        }

        [TestMethod]
        public void Case_DeadCell_ChouldBeDeadThenNeigboursCountLessThree()
        {
            var initialState = CellState.Dead;
            var state1 = LifeEngineRules.NextState(initialState, 2);

            Assert.AreEqual(state1, CellState.Dead);
        }
    }
}
