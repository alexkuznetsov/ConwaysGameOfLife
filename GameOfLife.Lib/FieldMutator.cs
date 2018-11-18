using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Lib
{
    public class FieldMutator
    {
        public FieldMutator(Field field)
            => Field = field;

        private Field Field { get; }

        public Field Mutate()
        {
            var state = Field.State;
            var newState = new int[Field.Size][];
            var finder = new AliveNeigboursCounter(Field);

            for (int i = 0; i < Field.Size; i++)
            {
                Array.Resize(ref newState[i], Field.Size);

                for (int j = 0; j < Field.Size; j++)
                {
                    var cellState = state[i][j] == 0 ? CellState.Dead : CellState.Alive;
                    var n = finder.Count(i, j);
                    var newCellState = LifeEngineRules.NextState(cellState, n);
                    newState[i][j] = newCellState == CellState.Alive ? 1 : 0;
                }
            }

            return new Field(newState);
        }
    }
}
