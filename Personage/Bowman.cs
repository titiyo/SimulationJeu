using System.Text;
using SimulationJeu.Behavior;
using SimulationJeu.Observer;

namespace SimulationJeu.Personage
{
    class Bowman : PersonageAbstract
    {
        public Bowman(string name, SubjectObservedAbstract generalStaff, FightBehaviorAbstract fightBehavior, MoveBehaviorAbstract moveBehavior, InteractionObjectBehaviorAbstract interactionObjectBehavior)
            : base(name, generalStaff, fightBehavior, moveBehavior, interactionObjectBehavior)
        {
            Pv = 40;
            DefaultPosition = 3;
            IndexOfDefaultGoalObject = 1;
            IndexOfDefaultGoalPosition = 2;
        }

        public override string Display()
        {
            StringBuilder perso = new StringBuilder();
            perso.Append(Name).Append(" (Archer)\n");
            perso.Append(" - PV : ").Append(Pv).Append("\n");
            perso.Append(" - Position : ").Append(Position.Afficher()).Append("\n"); ;
            perso.Append(" - Objets : ").Append("\n");
            foreach (var item in Objects)
            {
                perso.Append("\t -").Append(item.Display()).Append("\n");
            }
            perso.Append(" - Objectif : ").Append("\n");
            foreach(var item in Goals)
            {
                perso.Append("\t - ").Append(item.Display()).Append("\n");
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
