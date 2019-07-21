using A_starAlgorithmTask.BL.Abstractions;
using Moq;
using Xunit;

namespace A_starAlgorithmTask.BL.Test
{
    public class ProcessTest
    {
        private readonly ICellsBuilder _cellsBuilder;
        private readonly IMoveToNextColor _moveToNextColor;
        private readonly IProgress _progress;

        private readonly IChangedCellNeighboursFinder _changedCellNeighboursFinder;
        private readonly IConnectedSameCellsFinder _connectedSameCellsFinder;

        private readonly Process _process;

        public ProcessTest()
        {
            _cellsBuilder = new CellsBuilder();
            _connectedSameCellsFinder = new ConnectedSameCellsFinder();
            _changedCellNeighboursFinder = new ChangedCellNeighboursFinder(_connectedSameCellsFinder);
            _moveToNextColor = new MoveToNextColor(_changedCellNeighboursFinder);

            var progressMock = new Mock<IProgress>();
            _progress = progressMock.Object;

            _process = new Process(_cellsBuilder, _moveToNextColor, _progress);
        }

        [Fact]
        public void ProcessTestReturns9()
        {
            int[,] array = new[,]
            {
                {0, 1, 2, 2, 3},
                {3, 3, 4, 4, 4},
                {3, 2, 1, 2, 6},
                {3, 1, 2, 1, 4},
                {3, 1, 2, 1, 4},
            };
            var expectedResult = 9;

            var result = _process.Execute(array);
            
            Assert.Equal(expectedResult,result);
        }
    }
}
