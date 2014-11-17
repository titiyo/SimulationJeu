using System;
using System.Collections.Generic;
using System.Linq;
using SimulationJeu.Environment;
using SimulationJeu.GameManagement;
using SimulationJeu.InitializationStrategy;
using SimulationJeu.ObjectItem;
using SimulationJeu.Observer;
using SimulationJeu.Personage;
using SimulationJeu.Zone;

namespace SimulationJeu.Simulation
{
    public class SimulationGrid : SimulationAbstract
    {
        public SimulationGrid(ExecutionModeEnum executionMode)
        {
            GameManagement = new GameManagementMedieval();
            GameEnvironment = new GridEnvironment();
            GameEngine = new SimulationEngine(executionMode);
        }

        private void CreateGameEnvironment()
        {
            /* Sans contrainte
                          X
                     __ __ __ __
                    |__   |   __|
                Y   |  |  |     |
                    |   __|__|  |
                    |__ __ __ __|

            */

            GameEnvironment.AddZone(1, 1, 0);
            GameEnvironment.AddZone(2, 1, 0);
            GameEnvironment.AddZone(3, 1, 0);
            GameEnvironment.AddZone(4, 1, 0);
            GameEnvironment.AddZone(1, 2, 0);
            GameEnvironment.AddZone(2, 2, 0);
            GameEnvironment.AddZone(3, 2, 0);
            GameEnvironment.AddZone(4, 2, 0);
            GameEnvironment.AddZone(1, 3, 0);
            GameEnvironment.AddZone(2, 3, 0);
            GameEnvironment.AddZone(3, 3, 0);
            GameEnvironment.AddZone(4, 3, 0);
            GameEnvironment.AddZone(1, 4, 0);
            GameEnvironment.AddZone(2, 4, 0);
            GameEnvironment.AddZone(3, 4, 0);
            GameEnvironment.AddZone(4, 4, 0);


            //// Y1
            // Y1 X1
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(1, 1, 0), GameEnvironment.GetZone(2, 1, 0));
            //EnvJeu.AddBidirectionnelLink(EnvJeu.GetZone(1, 1, 0), EnvJeu.GetZone(1, 2, 0));

            // Y1 X2
           // EnvJeu.AddBidirectionnelLink(EnvJeu.GetZone(2, 1, 0), EnvJeu.GetZone(3, 1, 0));
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(2, 1, 0), GameEnvironment.GetZone(2, 2, 0));

            // Y1 X3
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(3, 1, 0), GameEnvironment.GetZone(4, 1, 0));
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(3, 1, 0), GameEnvironment.GetZone(3, 2, 0));

            // Y1 X4
            //EnvJeu.AddBidirectionnelLink(EnvJeu.GetZone(4, 1, 0), EnvJeu.GetZone(4, 2, 0));

            //// Y2
            // Y2 X1
            //EnvJeu.AddBidirectionnelLink(EnvJeu.GetZone(1, 2, 0), EnvJeu.GetZone(2, 2, 0));
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(1, 2, 0), GameEnvironment.GetZone(1, 3, 0));

            // Y2 X2
            //EnvJeu.AddBidirectionnelLink(EnvJeu.GetZone(2, 2, 0), EnvJeu.GetZone(3, 2, 0));
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(2, 2, 0), GameEnvironment.GetZone(2, 3, 0));
            
            // Y2 X3
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(3, 2, 0), GameEnvironment.GetZone(4, 2, 0));
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(3, 2, 0), GameEnvironment.GetZone(3, 3, 0));

            // Y2 X4
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(4, 2, 0), GameEnvironment.GetZone(4, 3, 0));

            //// Y3
            // Y3 X1
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(1, 3, 0), GameEnvironment.GetZone(2, 3, 0));
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(1, 3, 0), GameEnvironment.GetZone(1, 4, 0));

            // Y3 X2
            //EnvJeu.AddBidirectionnelLink(EnvJeu.GetZone(2, 3, 0), EnvJeu.GetZone(3, 3, 0));
            //EnvJeu.AddBidirectionnelLink(EnvJeu.GetZone(2, 3, 0), EnvJeu.GetZone(2, 4, 0));

            // Y3 X3
            //EnvJeu.AddBidirectionnelLink(EnvJeu.GetZone(3, 3, 0), EnvJeu.GetZone(4, 3, 0));
            //EnvJeu.AddBidirectionnelLink(EnvJeu.GetZone(3, 3, 0), EnvJeu.GetZone(3, 4, 0));

            // Y3 X4
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(4, 3, 0), GameEnvironment.GetZone(4, 4, 0));

            //// Y4
            // Y4 X1
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(1, 4, 0), GameEnvironment.GetZone(2, 4, 0));

            // Y4 X2
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(2, 4, 0), GameEnvironment.GetZone(3, 4, 0));

            // Y4 X3
            GameEnvironment.AddBidirectionalLink(GameEnvironment.GetZone(3, 4, 0), GameEnvironment.GetZone(4, 4, 0));
        }

        private void CreateObjects(List<ZoneAbstract> zones)
        {
            GameManagement.LoadObject(TypeObjectEnum.Food, "Eau", zones.ElementAt(1));
            GameManagement.LoadObject(TypeObjectEnum.Trap, "Piege 1", zones.ElementAt(3));
            GameManagement.LoadObject(TypeObjectEnum.Treasure, "Tresor 1", zones.ElementAt(6));
            GameManagement.LoadObject(TypeObjectEnum.Vehicle, "Tank", zones.ElementAt(4));
            GameManagement.LoadObject(TypeObjectEnum.Visibility, "Visibilite 1", zones.ElementAt(8));
            ((ObjectItem.Visibility)GameManagement.Objects.Where(x => x.GetName() == "Visibilite 1").First()).SetVisibilite(3);
            GameEnvironment.LoadObject(GameManagement.Objects.ToList());
        }

        private void CreatePersonage()
        {
            GameManagement.LoadPersonage(TypePersonageEnum.Archer, "Tiyo");
            GameManagement.LoadPersonage(TypePersonageEnum.Fantassin, "JuJu");
            GameManagement.LoadPersonage(TypePersonageEnum.Princesse, "Chris");
        }

        private void CreateGeneralStaff()
        {
            GameManagement.LoadGeneralStaff(TypeSubjectObservedEnum.GeneralStaff, "Chef des armés");
        }

        public override void LoadSimulation(InitializationStrategyEnum lifePointInitializationStrategy,
            InitializationStrategyEnum positionInitializationStrategy,
            InitializationStrategyEnum goalInitializationStrategy,
            InitializationStrategyEnum behaviorInitializationStrategy)
        {
            CreateGameEnvironment();
            CreateObjects(GameEnvironment.Zones.ToList());
            CreatePersonage();
            CreateGeneralStaff();
            foreach (var item in GameManagement.Personages)
            {
                InitializationStrategyPv initViePerso = new InitializationStrategyPv(lifePointInitializationStrategy);
                initViePerso.Initialization(item);

                InitializationStrategyPosition initPositionnementPerso = new InitializationStrategyPosition(positionInitializationStrategy, GameEnvironment.Zones.ToList());
                initPositionnementPerso.Initialization(item);

                InitializationStrategyGoal initObjectifPerso = new InitializationStrategyGoal(goalInitializationStrategy, GameEnvironment.Zones.ToList(), GameManagement.Objects.ToList());
                initObjectifPerso.Initialization(item);

                InitializationStrategyBehavior initComportementPerso = new InitializationStrategyBehavior(behaviorInitializationStrategy);
                initComportementPerso.Initialization(item);
            }

            GameEnvironment.LoadPersonage(GameManagement.Personages.ToList());
        }

        public override void DisplayAllPersonages()
        {
            Console.WriteLine("////////////////////////////////////////////////");
            Console.WriteLine("//           Personnages :                   ///");
            Console.WriteLine("////////////////////////////////////////////////");
            Console.WriteLine("\n");
            foreach (var item in GameManagement.Personages)
            {
                Console.WriteLine(item.Display());
            }
            Console.WriteLine("\n");
        }

        public override void DisplayAllObjects()
        {
            Console.WriteLine("////////////////////////////////////////////////");
            Console.WriteLine("//                   Objets :                  //");
            Console.WriteLine("////////////////////////////////////////////////");
            Console.WriteLine("\n");
            foreach (var item in GameManagement.Objects)
            {
                Console.WriteLine(item.Display());
            }
            Console.WriteLine("\n");
        }

    }
}
