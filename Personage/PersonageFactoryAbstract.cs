namespace SimulationJeu.Personage
{
    public abstract class PersonageFactoryAbstract
    {
        public abstract PersonageAbstract CreatePersonage(TypePersonageEnum typeOfPersonage, string name);
    }
}
