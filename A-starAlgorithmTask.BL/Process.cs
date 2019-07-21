using A_starAlgorithmTask.BL.Abstractions;
using A_starAlgorithmTask.DataObject;
using System.Collections.Generic;

namespace A_starAlgorithmTask
{
    public class Process: IProcess
    {
        private readonly ICellsBuilder _cellsBuilder;
        private readonly IMoveToNextColor _moveToNextColor;
        private readonly IProgress _progress;

        public Process(ICellsBuilder cellsBuilder, 
                       IMoveToNextColor moveToNextColor,
                       IProgress progress)
        {
            _cellsBuilder = cellsBuilder;
            _moveToNextColor = moveToNextColor;
            _progress = progress;
        }

        public int Execute(int[,] array)
        {
            var result = 0;

            var cells = _cellsBuilder.Build(array);
            while (!AllCellsHaveSameColor(cells))
            {
                result = result + 1;
                _moveToNextColor.Move(cells);
                _progress.ProcessProgress(cells);
            }

            return result;
        }

        private bool AllCellsHaveSameColor(IList<Cell> cells)
        {
            var count = cells.Count;
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i; j < count; j++)
                {
                    if (cells[i].Color != cells[j].Color) return false;
                }
            }
            return true;
        }
    }
}
