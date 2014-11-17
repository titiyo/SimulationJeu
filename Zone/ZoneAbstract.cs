using System.Collections.ObjectModel;
using SimulationJeu.ObjectItem;
using SimulationJeu.Personage;

namespace SimulationJeu.Zone
{
    public abstract class ZoneAbstract
    {
        public int X, Y, Z;
        public ObservableCollection<ZoneAbstract> links;
        public ObservableCollection<PersonageAbstract> personages;
        public ObservableCollection<ObjectItemAbstract> objects;

        public abstract void AddLink(ZoneAbstract zoneCible);
        public abstract bool ExistingLink(ZoneAbstract zoneCible);
        public ZoneAbstract(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
            links = new ObservableCollection<ZoneAbstract>();
            personages = new ObservableCollection<PersonageAbstract>();
            objects = new ObservableCollection<ObjectItemAbstract>();
        }

        public string Afficher()
        {
            return " X : " + X + ", Y : " + Y + ", Z : " + Z;
        }
    }
}
