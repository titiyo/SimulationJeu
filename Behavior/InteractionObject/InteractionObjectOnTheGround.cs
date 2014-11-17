
namespace SimulationJeu.Behavior.InteractionObject
{
    class InteractionObjectOnTheGround : InteractionObjectBehaviorAbstract
    {
        public InteractionObjectOnTheGround()
            : base()
        {
        }

        public override string CollectObject()
        {
            return "Je ramasse les objets en m'accroupissant.";
        }

        public override string PoseObject()
        {
            return "Je pose les objets sur le sol !";
        }
    }
}
