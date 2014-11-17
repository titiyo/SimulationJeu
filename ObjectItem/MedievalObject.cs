using System;
using SimulationJeu.Zone;

namespace SimulationJeu.ObjectItem
{
    public class MedievalObject : ObjectItemFactoryAbstract
    {
        public override ObjectItemAbstract CreateObject(TypeObjectEnum typeOfObject, string name, ZoneAbstract position)
        {
            switch (typeOfObject)
            {
                case TypeObjectEnum.Food:
                    return new Food(name, position);
                case TypeObjectEnum.Trap:
                    return new Trap(name, position);
                case TypeObjectEnum.Treasure:
                    return new Treasure(name, position);
                case TypeObjectEnum.Vehicle:
                    return new Vehicle(name, position);
                case TypeObjectEnum.Visibility:
                    return new Visibility(name, position);
                default:
                    throw new ArgumentException("The object type " + typeOfObject + " is not recognized.");
            }
        }
    }
}
