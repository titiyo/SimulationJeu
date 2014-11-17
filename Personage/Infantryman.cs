using System.Text;
using SimulationJeu.Behavior;
using SimulationJeu.Observer;

namespace SimulationJeu.Personage
{
    class Infantryman : PersonageAbstract
    {
        public Infantryman(string name, SubjectObservedAbstract generalStaff, FightBehaviorAbstract fightBehavior, MoveBehaviorAbstract moveBehavior, InteractionObjectBehaviorAbstract interactionObjectBehavior)
            : base(name, generalStaff, fightBehavior, moveBehavior, interactionObjectBehavior)
        {
            Pv = 50;
            DefaultPosition = 5;
            DefaultPosition = 1;
            IndexOfDefaultGoalObject = 2;
            IndexOfDefaultGoalPosition = 4;
        }

        public override string Display()
        {
            StringBuilder perso = new StringBuilder();
            perso.Append(Name).Append(" (Fantassin)\n");
            perso.Append(" - PV : ").Append(Pv).Append("\n");
            perso.Append(" - Position : ").Append(Position.Afficher()).Append("\n");
            perso.Append(" - Objets : ").Append("\n");
            foreach (var item in Objects)
            {
                perso.Append("\t -").Append(item.Display()).Append("\n");
            }
            perso.Append(" - Objectif : ").Append("\n");
            foreach (var item in Goals)
            {
                perso.Append("\t* ").Append(item.Display()).Append("\n");
            }
            if (FightBehavior != null)
                perso.Append(" - Comportement Combat : ").Append(FightBehavior.Attack()).Append("\n");
            if (MoveBehavior != null)
                perso.Append(" - Comportement Deplacement : ").Append(MoveBehavior.Move()).Append("\n");
            if (InteractionObjectBehavior != null)
                perso.Append(" - Comportement Interaction objet : ").Append(InteractionObjectBehavior.CollectObject())
                    .Append(" Et ").Append(InteractionObjectBehavior.PoseObject()).Append("\n");

            return perso.ToString();
        }
    }
}
