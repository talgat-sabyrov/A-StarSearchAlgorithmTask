using System;
using System.Collections.Generic;
using A_starAlgorithmTask.BL.Abstractions;
using Autofac;
using A_starAlgorithmTask.DataObject;

namespace A_starAlgorithmTask.Console
{
    class Program
    {
        private static readonly IProcess _process;
        private static readonly IProgress _progress;

        static Program()
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                _process = scope.Resolve<IProcess>();
                _progress = scope.Resolve<IProgress>();
            }
        }

        static void Main(string[] args)
        {
            System.Console.Write("NxN matrix. Enter N: ");
            var n = Convert.ToInt32(System.Console.ReadLine());
            int[,] array = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    System.Console.Write("element - [{0},{1}] : ", i, j);
                    array[i, j] = Convert.ToInt32(System.Console.ReadLine());
                }
            }

            /*int[,] array = new[,]
            {
                {0, 1, 2, 2, 3},
                {3, 3, 4, 4, 4},
                {3, 2, 1, 2, 6},
                {3, 1, 2, 1, 4},
                {3, 1, 2, 1, 4},
            };*/

            _progress.ProcessProgressedEvent += ProgressBar;

            var result = _process.Execute(array);

            System.Console.WriteLine("Result: " + result.ToString());
            System.Console.ReadLine();
        }

        private static void ProgressBar(IList<Cell> cells)
        {
            int i = 0;
            foreach (var cell in cells)
            {
                if (cell.I != i)
                    System.Console.WriteLine();
                if (cell.Changed)
                    System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Write("{0} ", cell.Color);
                i = cell.I;

                System.Console.ResetColor();
            }

            System.Console.WriteLine();
            System.Console.WriteLine("---------------");
        }
    }
}
