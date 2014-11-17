using SimulationJeu.Environment;
using SimulationJeu.GameManagement;
using SimulationJeu.InitializationStrategy;

namespace SimulationJeu.Simulation
{
    public abstract class SimulationAbstract
    {
        // Environnement de Zones
        public EnvironmentAbstract GameEnvironment;
        // Gestion des personnages et des objets
        public GameManagementAbstract GameManagement;
        // Moteur de simulation
        public SimulationEngine GameEngine;
        // Module de statistique

        public abstract void LoadSimulation(InitializationStrategyEnum lifePointInitializationStrategy, 
            InitializationStrategyEnum positionInitializationStrategy, 
            InitializationStrategyEnum goalInitializationStrategy,
            InitializationStrategyEnum behaviorInitializationStrategy);

        public abstract void DisplayAllPersonages();
        public abstract void DisplayAllObjects();
    }
}
