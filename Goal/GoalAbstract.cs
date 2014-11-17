
namespace SimulationJeu.Goal
{
    public abstract class GoalAbstract
    {
        protected bool Completed;
        protected string Description;
        protected string Title;

        public abstract bool GoalIsCompleted();
        public abstract string Display();

        protected GoalAbstract(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void SetCompleted(bool status)
        {
            Completed = status;
        }
    }
}
