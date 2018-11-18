namespace GameOfLife.Lib
{
    public class AliveNeigboursCounter
    {
        public AliveNeigboursCounter(Field field)
        {
            Field = field;
        }

        private Field Field { get; }

        public int Count(int x, int y)
        {
            var alive = 0;

            for (int k = x - 1; k <= x + 1; k++)
            {
                for (int v = y - 1; v <= y + 1; v++)
                {
                    var isNotOutFromTopAndLeft
                        = k >= 0 && v >= 0;

                    var isNotOutFromRightAndBottom
                        = k < Field.State.Length &&
                          v < Field.State.Length;

                    var isNotInCellPoint = k != x || v != y;

                    if (isNotOutFromTopAndLeft && isNotOutFromRightAndBottom && isNotInCellPoint)
                    {
                        alive += Field.State[k][v];
                    }
                }
            }

            return alive;
        }
    }
}
