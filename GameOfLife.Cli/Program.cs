using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new System.Threading.CancellationTokenSource();
            var runner = new GameOfLifeRunner(cts);

            runner.Run();
            
            Console.ReadLine();
            cts.Cancel();

        }
    }
}
