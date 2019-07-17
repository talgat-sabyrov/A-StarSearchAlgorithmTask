﻿using System.Collections.Generic;
using System.Linq;

namespace A_starAlgorithmTask
{
    public class CellsBuilder
    {
        public IList<Cell> Build(int[,] array)
        {
            var cells = new List<Cell>();
            var n = array.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var cell = new Cell();
                    cell.I = i;
                    cell.J = j;
                    cell.Color = array[i,j];
                    if (i > 0)
                    {
                        var northCell = cells.Single(x => x.I == i - 1 && x.J == j);
                        cell.NorthCell = northCell;
                        northCell.SouthCell = cell;
                    }
                    if (j > 0)
                    {
                        var westCell = cells.Single(x => x.I == i && x.J == j - 1);
                        cell.WestCell = westCell;
                        westCell.EastCell = cell;
                    }

                    cells.Add(cell);
                }
            }
            return cells;
        }
    }
}
