using System.Collections.Generic;
using System.Linq;

namespace A_starAlgorithmTask
{
    public class ConnectedSameCells
    {
        private IList<Cell> connectedCells;
        private int Color;

        public ConnectedSameCells()
        {
            connectedCells = new List<Cell>();
        }

        public IList<Cell> Get(Cell cell)
        {
            connectedCells.Add(cell);
            Color = cell.Color;
            Search(cell);
            return connectedCells;
        }

        private void Search(Cell cell)
        {
            var northCell = cell.NorthCell;
            if (northCell != null && northCell.Color == Color && !connectedCells.Any(x=> x.I == northCell.I && x.J == northCell.J))
            {
                connectedCells.Add(northCell);
                Search(northCell);
            }

            var eastCell = cell.EastCell;
            if (eastCell != null && eastCell.Color == Color && !connectedCells.Any(x => x.I == eastCell.I && x.J == eastCell.J))
            {
                connectedCells.Add(eastCell);
                Search(eastCell);
            }

            var southCell = cell.SouthCell;
            if (southCell != null && southCell.Color == Color && !connectedCells.Any(x => x.I == southCell.I && x.J == southCell.J))
            {
                connectedCells.Add(southCell);
                Search(southCell);
            }

            var westCell = cell.WestCell;
            if (westCell != null && westCell.Color == Color && !connectedCells.Any(x => x.I == westCell.I && x.J == westCell.J))
            {
                connectedCells.Add(westCell);
                Search(westCell);
            }
        }
    }
}
