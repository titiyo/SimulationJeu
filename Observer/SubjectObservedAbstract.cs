using System.Collections.Generic;

namespace SimulationJeu.Observer
{
    public abstract class SubjectObservedAbstract
    {
        string Name;
        public ModeEnum OperatingMode { get; set; }
        public GeneralStaff Parent { get; set; }

        public SubjectObservedAbstract(string name)
        {
            Name = name;
        }

        abstract public void Attach(ObserverAbstract observer);
        abstract public void Detach(ObserverAbstract observer);
        abstract public void Update();

        protected List<ObserverAbstract> Observers { get; set; }
    }
}
