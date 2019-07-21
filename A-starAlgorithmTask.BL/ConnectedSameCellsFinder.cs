using System.Collections.Generic;
using System.Linq;
using A_starAlgorithmTask.BL.Abstractions;
using A_starAlgorithmTask.DataObject;

namespace A_starAlgorithmTask.BL
{
    public class ConnectedSameCellsFinder: IConnectedSameCellsFinder
    {
        private IList<Cell> connectedCells;
        private int Color;
        
        public IList<Cell> Find(Cell cell)
        {
            if (cell==null || cell.Changed) return null;
            connectedCells = new List<Cell>();
            connectedCells.Add(cell);
            Color = cell.Color;
            SearchDeeper(cell);
            return connectedCells;
        }

        private void SearchDeeper(Cell cell)
        {
            var northCell = cell.NorthCell;
            if (CellCanBeAdded(northCell))
            {
                connectedCells.Add(northCell);
                SearchDeeper(northCell);
            }

            var eastCell = cell.EastCell;
            if (CellCanBeAdded(eastCell))
            {
                connectedCells.Add(eastCell);
                SearchDeeper(eastCell);
            }

            var southCell = cell.SouthCell;
            if (CellCanBeAdded(southCell))
            {
                connectedCells.Add(southCell);
                SearchDeeper(southCell);
            }

            var westCell = cell.WestCell;
            if (CellCanBeAdded(westCell))
            {
                connectedCells.Add(westCell);
                SearchDeeper(westCell);
            }
        }

        private bool CellCanBeAdded(Cell cell)
        {
            return cell != null &&
                   cell.Color == Color &&
                   !connectedCells.Any(x => x.I == cell.I && x.J == cell.J) &&
                   !cell.Changed;
        }
    }
}
