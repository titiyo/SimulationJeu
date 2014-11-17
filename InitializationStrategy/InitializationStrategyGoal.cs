using System;
using System.Collections.Generic;
using System.Linq;
using SimulationJeu.Goal;
using SimulationJeu.ObjectItem;
using SimulationJeu.Personage;
using SimulationJeu.Zone;

namespace SimulationJeu.InitializationStrategy
{
    class InitializationStrategyGoal : InitializationStrategyAbstract
    {
        List<ZoneAbstract> Zones;
        List<ObjectItemAbstract> Objects;

        public InitializationStrategyGoal(InitializationStrategyEnum strategy, List<ZoneAbstract> zones, List<ObjectItemAbstract> objects)
            : base(strategy)
        {
            Zones = zones;
            Objects = objects;
        }

        public override void Initialization(PersonageAbstract perso)
        {
            ZoneAbstract zone;
            ObjectItemAbstract obj;
            switch (Strategy)
            {
                case InitializationStrategyEnum.Random:
                    obj = Objects.ElementAt(Random.Next(0, Objects.Count()));
                    perso.AddGoal(new GoalObject("Objectf 1 : Recupération d'un objet.", "Veuillez récupérer l'objet : " + obj.Display(), obj));

                    zone = Zones.ElementAt(Random.Next(0, Zones.Count()));
                    perso.AddGoal(new GoalPosition("Objectf 2 : Destination.", "Veuillez allez à la position : " + zone.Afficher(), zone));

                    break;

                case InitializationStrategyEnum.Identic:
                    obj = Objects.ElementAt(0);
                    perso.AddGoal(new GoalObject("Objectf 1 : Recupération d'un objet.", "Veuillez récupérer l'objet : " + obj.Display(), obj));

                    zone = Zones.ElementAt(0);
                    perso.AddGoal(new GoalPosition("Objectf 2 : Destination.", "Veuillez allez à la position : " + zone.Afficher(), zone));

                    break;

                case InitializationStrategyEnum.DependingTypeOfPersonage:
                    obj = Objects.ElementAt(perso.GetIndexOfDefaultGoalObject());
                    perso.AddGoal(new GoalObject("Objectf 1 : Recupération d'un objet.", "Veuillez récupérer l'objet : " + obj.Display(), obj));

                    zone = Zones.ElementAt(perso.GetIndexOfDefaultGoalPosition());
                    perso.AddGoal(new GoalPosition("Objectf 2 : Destination.", "Veuillez allez à la position : " + zone.Afficher(), zone));

                    break;
            }
        }
    }
}
