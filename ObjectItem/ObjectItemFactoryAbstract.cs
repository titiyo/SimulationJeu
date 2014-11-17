using SimulationJeu.Zone;

namespace SimulationJeu.ObjectItem
{
    public abstract class ObjectItemFactoryAbstract
    {
        public abstract ObjectItemAbstract CreateObject(TypeObjectEnum typeOfObject, string name, ZoneAbstract position);
    }
}
