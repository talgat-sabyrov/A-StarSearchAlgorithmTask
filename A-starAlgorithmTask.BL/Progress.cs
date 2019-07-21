using System.Collections.Generic;
using A_starAlgorithmTask.BL.Abstractions;
using A_starAlgorithmTask.DataObject;

namespace A_starAlgorithmTask.BL
{
    public class Progress : IProgress
    {
        public event ProcessProgress ProcessProgressedEvent;
        
        public void ProcessProgress(IList<Cell> cells)
        {
            ProcessProgressedEvent?.Invoke(cells);
        }
    }
}
