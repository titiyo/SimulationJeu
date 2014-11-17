using System.Collections.Generic;

namespace SimulationJeu.Observer
{
    public class GeneralStaff : SubjectObservedAbstract
    {
        public GeneralStaff(string name) 
            : base(name)
        {
            Observers = new List<ObserverAbstract>();
            OperatingMode = ModeEnum.inPeace;
        }

        public GeneralStaff(string name, GeneralStaff parent)
            : base(name)
        {
            Parent = parent;
            OperatingMode = ModeEnum.inPeace;
            Observers = new List<ObserverAbstract>();
        }

        public override void Attach(ObserverAbstract observer)
        {
            Observers.Add(observer);
        }

        public override void Detach(ObserverAbstract observer)
        {
            Observers.Remove(observer);
        }

        public override void Update()
        {
            foreach (var o in Observers)
            {
                o.Update();
            }
        }
    }
}
