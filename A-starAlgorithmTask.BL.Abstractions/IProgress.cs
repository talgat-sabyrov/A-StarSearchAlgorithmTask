using A_starAlgorithmTask.DataObject;
using System.Collections.Generic;

namespace A_starAlgorithmTask.BL.Abstractions
{
    public delegate void ProcessProgress(IList<Cell> cells);
    public interface IProgress
    {
        event ProcessProgress ProcessProgressedEvent;
        void ProcessProgress(IList<Cell> cells);
    }
}
