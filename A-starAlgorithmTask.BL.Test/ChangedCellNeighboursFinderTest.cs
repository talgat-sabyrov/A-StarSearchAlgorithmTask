using A_starAlgorithmTask.DataObject;
using System.Collections.Generic;
using A_starAlgorithmTask.BL.Abstractions;
using Xunit;
using A_starAlgorithmTask.BL.Extensions;
using A_starAlgorithmTask.BL;

namespace A_starAlgorithmTask.Test
{
    public class ChangedCellNeighboursFinderTest
    {
        private readonly ChangedCellNeighboursFinder _changedCellNeighboursFinder;

        private readonly ICellsBuilder _cellsBuilder;
        private readonly IConnectedSameCellsFinder _connectedSameCellsFinder;

        private readonly IList<Cell> _cells;
        
        public ChangedCellNeighboursFinderTest()
        {
            _connectedSameCellsFinder = new ConnectedSameCellsFinder();
            _changedCellNeighboursFinder = new ChangedCellNeighboursFinder(_connectedSameCellsFinder);
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

            _cells.GetCell(0, 0).Changed = true;
        }

        [Fact]
        public void ActiveCellNeighboursFinderTest1()
        {
            var expectedResult = new List<Cell>
            {
                _cells.GetCell(0, 1),
                _cells.GetCell(1, 0),
                _cells.GetCell(1, 1),
                _cells.GetCell(2, 0),
                _cells.GetCell(3, 0),
                _cells.GetCell(4, 0)
            };

            var result = _changedCellNeighboursFinder.Find(_cells);

            Assert.Equal(expectedResult.Count, result.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(expectedResult[i].Color, result[i].Color);
                Assert.Equal(expectedResult[i].I, result[i].I);
                Assert.Equal(expectedResult[i].J, result[i].J);
            }
        }

        [Fact]
        public void ActiveCellNeighboursFinderTest2()
        {
            _cells.GetCell(1, 0).Changed = true;
            _cells.GetCell(1, 1).Changed = true;
            _cells.GetCell(2, 0).Changed = true;
            _cells.GetCell(3, 0).Changed = true;
            _cells.GetCell(4, 0).Changed = true;

            var expectedResult = new List<Cell>
            {
                _cells.GetCell(0, 1),
                _cells.GetCell(1, 2),
                _cells.GetCell(1, 3),
                _cells.GetCell(1, 4),
                _cells.GetCell(2, 1),
                _cells.GetCell(3, 1),
                _cells.GetCell(4, 1)
            };

            var result = _changedCellNeighboursFinder.Find(_cells);

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
