
namespace SimulationJeu.Behavior.Move
{
    class MoveWalk : MoveBehaviorAbstract
    {
        public MoveWalk()
            : base()
        {
        }

        public override string Move()
        {
 	        return "Je me déplace seulement en ligne droite";
        }
    }
}
