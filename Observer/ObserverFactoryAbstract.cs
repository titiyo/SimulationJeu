namespace SimulationJeu.Observer
{
    public abstract class ObserverFactoryAbstract
    {
        public abstract SubjectObservedAbstract CreateSubjectObserved(TypeSubjectObservedEnum typeOfSubjectObserved, string name);
    }
}
