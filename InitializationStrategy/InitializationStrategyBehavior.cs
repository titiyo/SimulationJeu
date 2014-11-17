using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimulationJeu.Behavior;
using SimulationJeu.Personage;

namespace SimulationJeu.InitializationStrategy
{
    class InitializationStrategyBehavior : InitializationStrategyAbstract
    {
        public InitializationStrategyBehavior(InitializationStrategyEnum strategy)
            : base(strategy)
        {
        }

        public override void Initialization(PersonageAbstract perso)
        {
            List<TypeInfo> comportementCombats = this.GetType().Assembly.DefinedTypes.Where(x => x.BaseType.Name == "FightBehaviorAbstract").ToList();
            List<TypeInfo> comportementDeplacement = this.GetType().Assembly.DefinedTypes.Where(x => x.BaseType.Name == "MoveBehaviorAbstract").ToList();
            List<TypeInfo> comportementInteractionObjet = this.GetType().Assembly.DefinedTypes.Where(x => x.BaseType.Name == "InteractionObjectBehaviorAbstract").ToList();

            switch (Strategy)
            {
                case InitializationStrategyEnum.Random:
                    perso.SetFightBehavior((FightBehaviorAbstract)Activator.CreateInstance(comportementCombats.ElementAt(Random.Next(0, comportementCombats.Count()))));
                    perso.SetMoveBehavior((MoveBehaviorAbstract)Activator.CreateInstance(comportementDeplacement.ElementAt(Random.Next(0, comportementDeplacement.Count()))));
                    perso.SetInteractionObjectBehavior((InteractionObjectBehaviorAbstract)Activator.CreateInstance(comportementInteractionObjet.ElementAt(Random.Next(0, comportementInteractionObjet.Count()))));
                    break;
                case InitializationStrategyEnum.Identic:
                    perso.SetFightBehavior((FightBehaviorAbstract)Activator.CreateInstance(comportementCombats.First()));
                    perso.SetMoveBehavior((MoveBehaviorAbstract)Activator.CreateInstance(comportementDeplacement.First()));
                    perso.SetInteractionObjectBehavior((InteractionObjectBehaviorAbstract)Activator.CreateInstance(comportementInteractionObjet.First()));
                    break;
            }
        }
    }
}
