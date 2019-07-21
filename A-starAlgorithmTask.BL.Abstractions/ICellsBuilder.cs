using A_starAlgorithmTask.DataObject;
using System.Collections.Generic;

namespace A_starAlgorithmTask.BL.Abstractions
{
    public interface ICellsBuilder
    {
        IList<Cell> Build(int[,] array);
    }
}
