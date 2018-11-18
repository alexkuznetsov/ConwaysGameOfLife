using System.Linq;

namespace GameOfLife.Lib
{
    public static class AliveCellFilter
    {
        public static int[] Apply(int[][] state)
        {
            return state.Cast<int[]>()
                .SelectMany(x => x)
                .Where(x => x > 0)
                .ToArray();
        }
    }
}
