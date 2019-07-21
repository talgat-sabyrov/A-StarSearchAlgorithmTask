using Autofac;
using A_starAlgorithmTask.BL.Abstractions;
using A_starAlgorithmTask.BL;

namespace A_starAlgorithmTask.Console
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CellsBuilder>().As<ICellsBuilder>();
            builder.RegisterType<ConnectedSameCellsFinder>().As<IConnectedSameCellsFinder>();
            builder.RegisterType<ChangedCellNeighboursFinder>().As<IChangedCellNeighboursFinder>();
            builder.RegisterType<MoveToNextColor>().As<IMoveToNextColor>();
            builder.Register(c => new Progress()).As<IProgress>().SingleInstance();
            builder.RegisterType<Process>().As<IProcess>();

            return builder.Build();
        }
    }
}
