using System.Collections.Generic;
using System.Collections.ObjectModel;
using SimulationJeu.ObjectItem;
using SimulationJeu.Personage;
using SimulationJeu.Zone;

namespace SimulationJeu.Environment
{
    public abstract class EnvironmentAbstract
    {
        public ObservableCollection<ZoneAbstract> Zones;

        public abstract void AddZone(int x, int y, int z);
        public abstract ZoneAbstract GetZone(int x, int y, int z);

        public abstract void AddBidirectionalLink(ZoneAbstract originZone, ZoneAbstract targetZone);
        public abstract void AddUnidirectionalLink(ZoneAbstract originZone, ZoneAbstract targetZone);

        public abstract void LoadObject(List<ObjectItemAbstract> objects);
        public abstract void LoadPersonage(List<PersonageAbstract> personages);

        public abstract void RemoveObject(ObjectItemAbstract obj);
        public abstract void RemovePersonage(PersonageAbstract perso);

        public abstract void AddPersonageInZone(PersonageAbstract perso, ZoneAbstract position);

        public abstract void DisplayEnvironment(PersonageAbstract personage);
        public abstract void DisplayEnvironmentWithPersonagesAndObjects();
        public abstract void DisplayEnvironmentWithVisibility(PersonageAbstract personage, List<ZoneAbstract> visibleZones);
    }
}
