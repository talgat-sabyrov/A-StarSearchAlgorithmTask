using System.Collections.Generic;
using System.Linq;

namespace A_starAlgorithmTask
{
    public class ConnectedSameCellsFinder
    {
        private IList<Cell> connectedCells;
        private int Color;

        public ConnectedSameCellsFinder()
        {
            connectedCells = new List<Cell>();
        }

        public IList<Cell> Find(Cell cell)
        {
            if (cell==null || cell.IsActive) return null;

            connectedCells.Add(cell);
            Color = cell.Color;
            Search(cell);
            return connectedCells;
        }

        private void Search(Cell cell)
        {
            var northCell = cell.NorthCell;
            if (CellCanBeAdded(northCell))
            {
                connectedCells.Add(northCell);
                Search(northCell);
            }

            var eastCell = cell.EastCell;
            if (CellCanBeAdded(eastCell))
            {
                connectedCells.Add(eastCell);
                Search(eastCell);
            }

            var southCell = cell.SouthCell;
            if (CellCanBeAdded(southCell))
            {
                connectedCells.Add(southCell);
                Search(southCell);
            }

            var westCell = cell.WestCell;
            if (CellCanBeAdded(westCell))
            {
                connectedCells.Add(westCell);
                Search(westCell);
            }
        }

        private bool CellCanBeAdded(Cell cell)
        {
            return cell != null &&
                   cell.Color == Color &&
                   !connectedCells.Any(x => x.I == cell.I && x.J == cell.J) &&
                   !cell.IsActive;
        }
    }
}
