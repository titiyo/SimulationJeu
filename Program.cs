using System;
using SimulationJeu.InitializationStrategy;
using SimulationJeu.Simulation;

namespace SimulationJeu
{
    class Program
    {
        static void Main(string[] args)
        {
            SimulationGrid simulation = new SimulationGrid(ExecutionModeEnum.automatic);
            simulation.LoadSimulation(InitializationStrategyEnum.Random, InitializationStrategyEnum.Random, InitializationStrategyEnum.Random, InitializationStrategyEnum.Random);
            simulation.DisplayAllPersonages();
            simulation.DisplayAllObjects();
            simulation.GameEnvironment.DisplayEnvironmentWithPersonagesAndObjects();

            Console.ReadKey();

            simulation.GameEngine.launch(simulation.GameManagement, simulation.GameEnvironment);
            Console.ReadLine();
        }
    }
}
