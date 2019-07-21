using A_starAlgorithmTask.DataObject;
using System.Collections.Generic;

namespace A_starAlgorithmTask.BL.Abstractions
{
    public interface IMoveToNextColor
    {
        void Move(IList<Cell> cells);
    }
}
