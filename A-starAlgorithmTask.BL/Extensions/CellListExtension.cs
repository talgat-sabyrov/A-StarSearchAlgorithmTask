using A_starAlgorithmTask.DataObject;
using System.Collections.Generic;
using System.Linq;

namespace A_starAlgorithmTask.BL.Extensions
{
    public static class CellListExtension
    {
        public static Cell GetCell(this IList<Cell> cells, int i, int j)
        {
            return cells.Single(x => x.I == i && x.J == j);
        }

        public static bool Contains(this IList<Cell> cells, Cell cell)
        {
            return cells.Any(x => x.I == cell.I && x.J == cell.J);
        }
    }
}
