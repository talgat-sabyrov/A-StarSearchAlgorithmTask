using A_starAlgorithmTask.BL.Abstractions;
using A_starAlgorithmTask.BL.Extensions;
using A_starAlgorithmTask.DataObject;
using System.Collections.Generic;
using Xunit;

namespace A_starAlgorithmTask.BL.Test
{
    public class ConnectedSameCellsTest
    {
        private readonly ConnectedSameCellsFinder _connectedSameCellsFinder;

        private readonly ICellsBuilder _cellsBuilder;

        private readonly IList<Cell> _cells;

        public ConnectedSameCellsTest()
        {
            _connectedSameCellsFinder = new ConnectedSameCellsFinder();
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
        /// <summary>
        /// Must return numbers 3 near the cell - 1:0
        /// </summary>
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

            var result = _connectedSameCellsFinder.Find(testedCell);

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
