using A_starAlgorithmTask.BL.Abstractions;
using A_starAlgorithmTask.BL.Extensions;
using A_starAlgorithmTask.DataObject;
using System.Collections.Generic;
using Xunit;

namespace A_starAlgorithmTask.BL.Test
{
    public class MoveToNextColorTest
    {
        private readonly MoveToNextColor _moveToNextColor;

        private readonly ICellsBuilder _cellsBuilder;
        private readonly IConnectedSameCellsFinder _connectedSameCellsFinder;
        private readonly IChangedCellNeighboursFinder _changedCellNeighboursFinder;

        private readonly IList<Cell> _cells;

        public MoveToNextColorTest()
        {
            _connectedSameCellsFinder = new ConnectedSameCellsFinder();
            _changedCellNeighboursFinder = new ChangedCellNeighboursFinder(_connectedSameCellsFinder);
            _moveToNextColor = new MoveToNextColor(_changedCellNeighboursFinder);
            _cellsBuilder = new CellsBuilder();
            int[,] array = new[,]
            {
                {0, 1, 2, 2, 3},
                {3, 3, 1, 4, 4},
                {3, 2, 1, 2, 6},
                {3, 1, 2, 1, 4},
                {3, 1, 2, 1, 4},
            };
            _cells = _cellsBuilder.Build(array);

            _cells.GetCell(0, 0).Changed = true;
        }

        [Fact]
        public void MoveToNextColorTest1()
        {
            var expectedColorForActiveCells = 3;
            var expectedActiveCells = new List<Cell>
            {
                _cells.GetCell(0, 0),
                _cells.GetCell(1, 0),
                _cells.GetCell(1, 1),
                _cells.GetCell(2, 0),
                _cells.GetCell(3, 0),
                _cells.GetCell(4, 0)
            };

            _moveToNextColor.Move(_cells);

            foreach (var expectedActiveCell in expectedActiveCells)
            {
                Assert.True(expectedActiveCell.Changed);
                Assert.Equal(expectedColorForActiveCells, expectedActiveCell.Color);
            }

            foreach (var cell in _cells)
            {
                if (!expectedActiveCells.Contains(cell))
                {
                    Assert.False(cell.Changed);
                }
            }
        }

        [Fact]
        public void MoveToNextColorTest2()
        {
            _cells.GetCell(1, 0).Changed = true;
            _cells.GetCell(1, 1).Changed = true;
            _cells.GetCell(2, 0).Changed = true;
            _cells.GetCell(3, 0).Changed = true;
            _cells.GetCell(4, 0).Changed = true;

            var expectedColorForActiveCells = 1;
            var expectedActiveCells = new List<Cell>
            {
                _cells.GetCell(0, 0),
                _cells.GetCell(0, 1),
                _cells.GetCell(1, 0),
                _cells.GetCell(1, 1),
                _cells.GetCell(1, 2),
                _cells.GetCell(2, 0),
                _cells.GetCell(2, 2),
                _cells.GetCell(3, 0),
                _cells.GetCell(3, 1),
                _cells.GetCell(4, 0),
                _cells.GetCell(4, 1)
            };

            _moveToNextColor.Move(_cells);

            foreach (var expectedActiveCell in expectedActiveCells)
            {
                Assert.True(expectedActiveCell.Changed);
                Assert.Equal(expectedColorForActiveCells, expectedActiveCell.Color);
            }

            foreach (var cell in _cells)
            {
                if (!expectedActiveCells.Contains(cell))
                {
                    Assert.False(cell.Changed);
                }
            }
        }
    }
}
