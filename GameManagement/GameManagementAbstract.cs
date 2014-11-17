using System.Collections.ObjectModel;
using SimulationJeu.ObjectItem;
using SimulationJeu.Observer;
using SimulationJeu.Personage;
using SimulationJeu.Zone;

namespace SimulationJeu.GameManagement
{
    public abstract class GameManagementAbstract
    {
        public ObservableCollection<PersonageAbstract> Personages;
        public ObservableCollection<SubjectObservedAbstract> GeneralStaffs;
        public ObservableCollection<ObjectItemAbstract> Objects;

        public abstract void LoadPersonage(TypePersonageEnum typeOfPersonnage, string name);
        public abstract void LoadGeneralStaff(TypeSubjectObservedEnum typeOfSubjectObserved, string name);
        public abstract void LoadObject(TypeObjectEnum typeOfObject, string name, ZoneAbstract position);

        public GameManagementAbstract()
        {
            Personages = new ObservableCollection<PersonageAbstract>();
            GeneralStaffs = new ObservableCollection<SubjectObservedAbstract>();
            Objects = new ObservableCollection<ObjectItemAbstract>();
        }
    }
}
