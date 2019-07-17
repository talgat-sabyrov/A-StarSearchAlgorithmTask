using System.Collections.Generic;
using System.Linq;

namespace A_starAlgorithmTask
{
    public static class CellListExtension
    {
        public static Cell GetCell(this IList<Cell> cells, int i, int j)
        {
            return cells.Single(x => x.I == i && x.J == j);
        }
    }
}
