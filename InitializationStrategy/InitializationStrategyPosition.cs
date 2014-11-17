using System;
using System.Collections.Generic;
using System.Linq;
using SimulationJeu.Personage;

namespace SimulationJeu.InitializationStrategy
{
    class InitializationStrategyPosition : InitializationStrategyAbstract
    {
        List<Zone.ZoneAbstract> Zones;

        public InitializationStrategyPosition(InitializationStrategyEnum strategy, List<Zone.ZoneAbstract> zones)
            : base(strategy)
        {
            Zones = zones;
        }

        public override void Initialization(PersonageAbstract perso)
        {
            switch (Strategy)
            {
                case InitializationStrategyEnum.Random:
                    perso.SetPosition(Zones.ElementAt(Random.Next(0, Zones.Count())));
                    break;
                case InitializationStrategyEnum.Identic:
                    perso.SetPosition(Zones.ElementAt(0));
                    break;
                case InitializationStrategyEnum.DependingTypeOfPersonage:
                    perso.SetPosition(Zones.ElementAt(perso.GetDefaultPosition()));
                    break;
            }
        }
    }
}
