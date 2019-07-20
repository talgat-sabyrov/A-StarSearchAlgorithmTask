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
            int[,] array = new[,]
            {
                {0, 1, 2, 2, 3},
                {3, 3, 4, 4, 4},
                {3, 2, 1, 2, 6},
                {3, 1, 2, 1, 4},
                {3, 1, 2, 1, 4},
            };
            var cells = cellBuilder.Build(array);



            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
