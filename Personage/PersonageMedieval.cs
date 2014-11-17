using System;
using SimulationJeu.Behavior.Fight;
using SimulationJeu.Behavior.InteractionObject;
using SimulationJeu.Behavior.Move;
using SimulationJeu.Observer;

namespace SimulationJeu.Personage
{
    public class PersonageMedieval : PersonageFactoryAbstract
    {
        public override PersonageAbstract CreatePersonage(TypePersonageEnum typeOfPersonage, string name)
        {
            switch (typeOfPersonage)
            {
                case TypePersonageEnum.Archer:
                    return new Bowman(name, new GeneralStaff("EtatMajor1"), new FightWithBow(), new MoveWalk(), new InteractionObjectOnTheGround());
                case TypePersonageEnum.Fantassin:
                    return new Infantryman(name, new GeneralStaff("EtatMajor1"), new FightWithAxe(), new MoveWithHorse(), new InteractionObjectOnTheGround());
                case TypePersonageEnum.Princesse:
                    return new Princess(name, new GeneralStaff("EtatMajor1"), new MoveWalk(), new InteractionObjectOnTheGround());
                default:
                    throw new ArgumentException("The personnage type " + typeOfPersonage + " is not recognized.");
            }
        }

    }
}
