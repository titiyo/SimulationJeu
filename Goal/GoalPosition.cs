using SimulationJeu.Zone;

namespace SimulationJeu.Goal
{
    class GoalPosition : GoalAbstract
    {
        ZoneAbstract Zone;

        public GoalPosition(string title, string description, ZoneAbstract zone)
            : base(title, description)
        {
            Zone = zone;
        }

        public void setPosition(ZoneAbstract zone)
        {
            Zone = zone;
        }

        public ZoneAbstract getPosition()
        {
            return Zone;
        }

        public override bool GoalIsCompleted()
        {
            return Completed;
        }

        public override string Display()
        {
            return Title + " (" + Zone.Afficher() + ") => Status : " + Completed;
        }
    }
}
