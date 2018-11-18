using GameOfLife.Lib;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife.Cli
{
    internal class GameOfLifeRunner
    {
        private readonly CancellationTokenSource cts;

        private Field Field { get; set; }

        public GameOfLifeRunner(CancellationTokenSource manualResetEvent)
        {
            this.cts = manualResetEvent;
            Field = new Field();
        }

        public void  Run()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(RunMutator), this.cts.Token);
        }

        private void RunMutator(object state)
        {
            int gen = 1;
            var c = (CancellationToken)state;
            while (true)
            {
                if (c.IsCancellationRequested)
                    return;

                PrintField(gen, Field.State);
                gen++;
                Field = (new FieldMutator(Field)).Mutate();

                Thread.Sleep(1000);
            }
        }

        private static void PrintField(int gen, int[][] state)
        {
            Console.Clear();
            Console.WriteLine("Gen: " + gen);
            Console.WriteLine();

            for (int i = 0; i < Field.Size; i++)
            {
                for (int j = 0; j < Field.Size; j++)
                {
                    var stateSymbol = state[i][j] == 0 ? "   " : " * ";
                    Console.Write(stateSymbol);
                }

                Console.WriteLine();
            }
        }
    }
}