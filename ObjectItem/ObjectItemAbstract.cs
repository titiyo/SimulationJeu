using SimulationJeu.Zone;

namespace SimulationJeu.ObjectItem
{
    public abstract class ObjectItemAbstract
    {
        protected string Name;
        protected ZoneAbstract Position;

        public ObjectItemAbstract(string name, ZoneAbstract position)
        {
            Name = name;
            Position = position;
        }

        public abstract string Display();

        public string GetName(){
            return Name;
        }

        public void SetZone(ZoneAbstract newPosition)
        {
            Position = newPosition;
        }

        public ZoneAbstract GetZone()
        {
            return Position;
        }
    }
}
