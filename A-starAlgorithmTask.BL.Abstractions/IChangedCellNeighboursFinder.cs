using A_starAlgorithmTask.DataObject;
using System.Collections.Generic;

namespace A_starAlgorithmTask.BL.Abstractions
{
    public interface IChangedCellNeighboursFinder
    {
        IList<Cell> Find(IList<Cell> cells);
    }
}
