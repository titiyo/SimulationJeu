using System;
using SimulationJeu.ObjectItem;
using SimulationJeu.Observer;
using SimulationJeu.Personage;
using SimulationJeu.Zone;

namespace SimulationJeu.GameManagement
{
    public class GameManagementMedieval : GameManagementAbstract
    {
        public override void LoadPersonage(TypePersonageEnum typeOfPersonnage, string name)
        {
            PersonageMedieval factory = new PersonageMedieval();

            switch (typeOfPersonnage)
            {
                case TypePersonageEnum.Archer:
                    Personages.Add(factory.CreatePersonage(typeOfPersonnage, name));
                    break;
                case TypePersonageEnum.Fantassin:
                    Personages.Add(factory.CreatePersonage(typeOfPersonnage, name));
                    break;
                case TypePersonageEnum.Princesse:
                    Personages.Add(factory.CreatePersonage(typeOfPersonnage, name));
                    break;
                default:
                    throw new ArgumentException("The personnage type " + typeOfPersonnage + " is not recognized.");
            }

        }

        public override void LoadGeneralStaff(TypeSubjectObservedEnum typeOfSubjectObserved, string name)
        {
            ObserverMedieval factory = new ObserverMedieval();

            switch (typeOfSubjectObserved)
            {
                case TypeSubjectObservedEnum.GeneralStaff:
                    GeneralStaffs.Add(factory.CreateSubjectObserved(typeOfSubjectObserved, name));
                    break;
                default:
                    throw new ArgumentException("The personnage type " + typeOfSubjectObserved + " is not recognized.");
            }
        }

        public override void LoadObject(TypeObjectEnum typeOfObject, string name, ZoneAbstract position)
        {
            MedievalObject fabrique = new MedievalObject();

            switch (typeOfObject)
            {
                case TypeObjectEnum.Food:
                    Objects.Add(fabrique.CreateObject(typeOfObject, name, position));
                    break;
                case TypeObjectEnum.Trap:
                    Objects.Add(fabrique.CreateObject(typeOfObject, name, position));
                    break;
                case TypeObjectEnum.Treasure:
                    Objects.Add(fabrique.CreateObject(typeOfObject, name, position));
                    break;
                case TypeObjectEnum.Vehicle:
                    Objects.Add(fabrique.CreateObject(typeOfObject, name, position));
                    break;
                case TypeObjectEnum.Visibility:
                    Objects.Add(fabrique.CreateObject(typeOfObject, name, position));
                    break;
                default:
                    throw new ArgumentException("The objet type " + typeOfObject + " is not recognized.");
            }
        }
    }
}
