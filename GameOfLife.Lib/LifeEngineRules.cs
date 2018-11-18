namespace GameOfLife.Lib
{
    public static class LifeEngineRules
    {
        /// <summary>
        /// Life state logic
        /// </summary>
        /// <param name="initialCellState"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static CellState NextState(CellState initialCellState, int n)
        {
            if (CellState.Alive == initialCellState)
            {
                if (n >= 2 && n <= 3)
                    return CellState.Alive;
            }

            if (n == 3)
                return CellState.Alive;

            return CellState.Dead;
        }
    }
}
