using System;
using System.Linq;
using GameOfLife.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLifeTests
{
    [TestClass]
    public class GenerationTests
    {
        [TestMethod]
        public void Case_StateShouldBeChanged()
        {
            var field = new Field();
            var mutator = new FieldMutator(field);

            var initialState = field.State.Cast<int[]>().SelectMany(x => x).ToArray();
            var newField = mutator.Mutate();
            var newState = newField.State.Cast<int[]>().SelectMany(x => x).ToArray();

            Assert.IsFalse(Enumerable.SequenceEqual(initialState, newState));

            
        }
    }
}
