using System;
using SimulationJeu.Personage;

namespace SimulationJeu.InitializationStrategy
{
    public class InitializationStrategyPv : InitializationStrategyAbstract
    {
        public InitializationStrategyPv(InitializationStrategyEnum strategy)
            : base(strategy)
        {
        }

        public override void Initialization(PersonageAbstract perso)
        {
            switch (Strategy)
            {
                case InitializationStrategyEnum.Random:
                    perso.SetPv(Random.Next(0, 100));
                    break;
                case InitializationStrategyEnum.Identic:
                    perso.SetPv(50);
                    break;
            }
        }
    }
}
