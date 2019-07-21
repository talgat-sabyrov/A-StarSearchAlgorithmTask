using System.Collections.Generic;
using System.Linq;
using A_starAlgorithmTask.BL.Abstractions;
using A_starAlgorithmTask.DataObject;

namespace A_starAlgorithmTask.BL
{
    public class MoveToNextColor: IMoveToNextColor
    {
        private readonly IChangedCellNeighboursFinder _changedCellNeighboursFinder;

        public MoveToNextColor(IChangedCellNeighboursFinder changedCellNeighboursFinder)
        {
            _changedCellNeighboursFinder = changedCellNeighboursFinder;
        }

        public void Move(IList<Cell> cells)
        {
            var changedCellConnectedNeighbours = _changedCellNeighboursFinder.Find(cells);
            var maxGroup = changedCellConnectedNeighbours.GroupBy(x => x.Color).OrderByDescending(x=>x.Count()).First();
            foreach (var cell in maxGroup)
            {
                cell.Changed = true;
            }
            foreach (var cell in cells.Where(x=>x.Changed))
            {
                cell.Color = maxGroup.Key;
            }
        }
    }
}
