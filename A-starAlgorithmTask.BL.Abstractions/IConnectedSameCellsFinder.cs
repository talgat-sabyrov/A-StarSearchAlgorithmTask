using A_starAlgorithmTask.DataObject;
using System.Collections.Generic;

namespace A_starAlgorithmTask.BL.Abstractions
{
    public interface IConnectedSameCellsFinder
    {
        IList<Cell> Find(Cell cell);
    }
}
