using SimulationJeu.ObjectItem;

namespace SimulationJeu.Goal
{
    class GoalObject : GoalAbstract
    {
        ObjectItemAbstract Object;

        public GoalObject(string title, string description, ObjectItemAbstract obj)
            : base(title, description)
        {
            Object = obj;
        }

        public void setObject(ObjectItemAbstract obj)
        {
            Object = obj;
        }

        public ObjectItemAbstract getObject()
        {
            return Object;
        }

        public override bool GoalIsCompleted()
        {
            return Completed;
        }

        public override string Display()
        {
            return Title + " (" + Object.GetName() + ") => Status : " + Completed;
        }
    }
}
