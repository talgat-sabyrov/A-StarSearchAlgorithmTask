using System.Collections.Generic;
using System.Linq;
using A_starAlgorithmTask.BL.Abstractions;
using A_starAlgorithmTask.DataObject;

namespace A_starAlgorithmTask.BL
{
    public class ChangedCellNeighboursFinder: IChangedCellNeighboursFinder
    {
        private readonly IConnectedSameCellsFinder _connectedSameCellsFinder;

        public ChangedCellNeighboursFinder(IConnectedSameCellsFinder connectedSameCellsFinder)
        {
            _connectedSameCellsFinder = connectedSameCellsFinder;
        }
        
        private IList<Cell> _activeCellConnectedNeighbours;

        public IList<Cell> Find(IList<Cell> cells)
        {
            _activeCellConnectedNeighbours = new List<Cell>();
            var activeCells = cells.Where(x => x.Changed);
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
