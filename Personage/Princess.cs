using System.Text;
using SimulationJeu.Behavior;
using SimulationJeu.Observer;

namespace SimulationJeu.Personage
{
    class Princess : PersonageAbstract
    {
        public Princess(string name, SubjectObservedAbstract generalStaff, MoveBehaviorAbstract moveBehavior, InteractionObjectBehaviorAbstract interactionObject)
            : base(name, generalStaff, null, moveBehavior, interactionObject)
        {
            Pv = 30;
            DefaultPosition = 6;
            DefaultPosition = 0;
            IndexOfDefaultGoalObject = 3;
            IndexOfDefaultGoalPosition = 6;
        }

        public override string Display()
        {
            StringBuilder perso = new StringBuilder();
            perso.Append(Name).Append(" (Princesse)\n");
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
            if(FightBehavior != null)
                perso.Append(" - Comportement Combat : ").Append(FightBehavior.Attack()).Append("\n");
            if(MoveBehavior != null)
                perso.Append(" - Comportement Deplacement : ").Append(MoveBehavior.Move()).Append("\n");
            if (InteractionObjectBehavior != null)
                perso.Append(" - Comportement Interaction objet : ").Append(InteractionObjectBehavior.CollectObject())
                    .Append(" Et ").Append(InteractionObjectBehavior.PoseObject()).Append("\n");

            return perso.ToString();
        }
    }
}
