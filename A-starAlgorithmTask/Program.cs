using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_starAlgorithmTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var cellBuilder = new CellsBuilder();
            int[,] array = new [,]
            {
                {0, 1, 2, 2},
                {3, 3, 4, 4},
                {1, 2, 1, 2},
                {3, 1, 2, 1}
            };
            var cells = cellBuilder.Build(array);
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
