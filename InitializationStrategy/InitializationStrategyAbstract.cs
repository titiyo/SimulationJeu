using System;
using SimulationJeu.Personage;

namespace SimulationJeu.InitializationStrategy
{
    public abstract class InitializationStrategyAbstract
    {
        protected static Random Random = new Random(unchecked((int)(DateTime.Now.Ticks)));

        protected InitializationStrategyEnum Strategy;

        public InitializationStrategyAbstract(InitializationStrategyEnum strategy)
        {
            Strategy = strategy;
        }

        public abstract void Initialization(PersonageAbstract perso);
    }
}
