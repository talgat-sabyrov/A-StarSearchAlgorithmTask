using System.Collections.Generic;
using Xunit;

namespace A_starAlgorithmTask.Test
{
    public class MoveToNextColorTest
    {
        private readonly MoveToNextColor _moveToNextColor;

        private readonly CellsBuilder _cellsBuilder;
        private readonly IList<Cell> _cells;

        public MoveToNextColorTest()
        {
            _moveToNextColor = new MoveToNextColor();
            _cellsBuilder = new CellsBuilder();
            int[,] array = new[,]
            {
                {0, 1, 2, 2, 3},
                {3, 3, 4, 4, 4},
                {3, 2, 1, 2, 6},
                {3, 1, 2, 1, 4},
                {3, 1, 2, 1, 4},
            };
            _cells = _cellsBuilder.Build(array);

            _cells.GetCell(0, 0).IsActive = true;
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
                Assert.True(expectedActiveCell.IsActive);
                Assert.Equal(expectedColorForActiveCells, expectedActiveCell.Color);
            }

            foreach (var cell in _cells)
            {
                if (!expectedActiveCells.Contains(cell))
                {
                    Assert.False(cell.IsActive);
                }
            }
        }

        [Fact]
        public void MoveToNextColorTest2()
        {
            _cells.GetCell(1, 0).IsActive = true;
            _cells.GetCell(1, 1).IsActive = true;
            _cells.GetCell(2, 0).IsActive = true;
            _cells.GetCell(3, 0).IsActive = true;
            _cells.GetCell(4, 0).IsActive = true;

            var expectedColorForActiveCells = 4;
            var expectedActiveCells = new List<Cell>
            {
                _cells.GetCell(0, 0),
                _cells.GetCell(1, 0),
                _cells.GetCell(1, 1),
                _cells.GetCell(1, 2),
                _cells.GetCell(1, 3),
                _cells.GetCell(1, 4),
                _cells.GetCell(2, 0),
                _cells.GetCell(3, 0),
                _cells.GetCell(4, 0)
            };

            _moveToNextColor.Move(_cells);

            foreach (var expectedActiveCell in expectedActiveCells)
            {
                Assert.True(expectedActiveCell.IsActive);
                Assert.Equal(expectedColorForActiveCells, expectedActiveCell.Color);
            }

            foreach (var cell in _cells)
            {
                if (!expectedActiveCells.Contains(cell))
                {
                    Assert.False(cell.IsActive);
                }
            }
        }
    }
}
