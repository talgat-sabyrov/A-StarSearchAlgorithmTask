using System.Collections.Generic;
using System.Linq;

namespace A_starAlgorithmTask
{
    public class ActiveCellNeighboursFinder
    {
        private readonly ConnectedSameCellsFinder _connectedSameCellsFinder = new ConnectedSameCellsFinder();

        private IList<Cell> _activeCellConnectedNeighbours;

        public IList<Cell> Find(IList<Cell> cells)
        {
            _activeCellConnectedNeighbours = new List<Cell>();
            var activeCells = cells.Where(x => x.IsActive);
            foreach (var activeCell in activeCells)
            {
                AddConnectedCells(activeCell.NorthCell);
                AddConnectedCells(activeCell.EastCell);
                AddConnectedCells(activeCell.SouthCell);
                AddConnectedCells(activeCell.WestCell);
            }
            return _activeCellConnectedNeighbours;
        }

        private void AddConnectedCells(Cell cell)
        {
            var connectedSameCells = _connectedSameCellsFinder.Find(cell);
            if (connectedSameCells != null)
            {
                foreach (var connectedSameCell in connectedSameCells)
                {
                    if (!_activeCellConnectedNeighbours.Contains(connectedSameCell))
                        _activeCellConnectedNeighbours.Add(connectedSameCell);
                }
            }
        }
    
    }
}
