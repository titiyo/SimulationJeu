using System;

namespace SimulationJeu.Observer
{
    public class ObserverMedieval : ObserverFactoryAbstract
    {
        public override SubjectObservedAbstract CreateSubjectObserved(TypeSubjectObservedEnum typeOfSubjectObserved, string name)
        {
            switch (typeOfSubjectObserved)
            {
                case TypeSubjectObservedEnum.GeneralStaff:
                    return new GeneralStaff(name);
                default:
                    throw new ArgumentException("The SujetObserve type " + typeOfSubjectObserved + " is not recognized.");
            }
        }
    }
}
