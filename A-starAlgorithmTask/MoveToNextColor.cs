using System.Collections.Generic;
using System.Linq;

namespace A_starAlgorithmTask
{
    public class MoveToNextColor
    {
        private readonly ActiveCellNeighboursFinder _activeCellNeighboursFinder;

        public MoveToNextColor()
        {
            _activeCellNeighboursFinder = new ActiveCellNeighboursFinder();
        }

        public void Move(IList<Cell> cells)
        {
            var activeCellConnectedNeighbours = _activeCellNeighboursFinder.Find(cells);
            var maxGroup = activeCellConnectedNeighbours.GroupBy(x => x.Color).OrderByDescending(x=>x.Key).First();
            foreach (var cell in maxGroup)
            {
                cell.IsActive = true;
            }
            foreach (var cell in cells)
            {
                cell.Color = maxGroup.Key;
            }
        }
    }
}
