namespace GameOfLife.Lib
{
    public class Field
    {
        public int[][] State { get; }

        public const int Size = 5;

        public Field() : this(new int[Size][]
        {
            new int[Size]{ 0,0,0,0,0 },
            new int[Size]{ 0,1,1,1,0 },
            new int[Size]{ 0,1,0,0,0 },
            new int[Size]{ 0,0,1,0,0 },
            new int[Size]{ 0,0,0,0,0 }
        })
        {

        }

        public Field(int[][] state)
            => State = state;
    }
}
