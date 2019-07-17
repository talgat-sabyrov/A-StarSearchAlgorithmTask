using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace A_starAlgorithmTask.Test
{
    public class ConnectedSameCellsTest
    {
        private readonly ConnectedSameCells _connectedSameCells;
        private readonly CellsBuilder _cellsBuilder;
        private readonly IList<Cell> _cells;

        public ConnectedSameCellsTest()
        {
            _connectedSameCells = new ConnectedSameCells();
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
        }

        [Fact]
        public void ConnectedSameCellsTest1()
        {
            var testedCell = _cells.GetCell(1, 0);
            var expectedResult = new List<Cell>
            {
                _cells.GetCell(1, 0),
                _cells.GetCell(1, 1),
                _cells.GetCell(2, 0),
                _cells.GetCell(3, 0),
                _cells.GetCell(4, 0)
            };

            var result = _connectedSameCells.Get(testedCell);

            Assert.Equal(expectedResult.Count, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(expectedResult[i].Color, result[i].Color);
                Assert.Equal(expectedResult[i].I, result[i].I);
                Assert.Equal(expectedResult[i].J, result[i].J);
            }
        }
    }
}
