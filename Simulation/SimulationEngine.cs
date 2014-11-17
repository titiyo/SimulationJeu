using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimulationJeu.Environment;
using SimulationJeu.GameManagement;
using SimulationJeu.Goal;
using SimulationJeu.ObjectItem;
using SimulationJeu.Personage;
using SimulationJeu.Zone;

namespace SimulationJeu.Simulation
{
    public class SimulationEngine
    {
        public ObjectAction ObjectAction;
        public MoveAction MoveAction;
        private ExecutionModeEnum ExecutionMode;

        public SimulationEngine(ExecutionModeEnum executionMode)
        {
            ExecutionMode = executionMode;
        }

        private void GetVisibilityZone(ZoneAbstract zone, int visibility, int counter, List<ZoneAbstract> visibleZones, ZoneAbstract previousZone)
        {
            foreach(var item in zone.links.Where(x=>x != previousZone))
            {
                if (counter < visibility)
                {
                    if (!visibleZones.Exists(x => x == item))
                    {
                        visibleZones.Add(item);
                    }
                    counter++;
                    GetVisibilityZone(item, visibility, counter, /*ref*/ visibleZones, zone);
                }
                counter = 0;
            }
        }

        private void ManualCollectObject(int compteurObj, PersonageAbstract personage)
        {
            string rammasser = "";
            while (rammasser.ToUpper() != "O" && rammasser.ToUpper() != "N")
            {
                Console.WriteLine("Voulez-vous rammasser un objet ? (O/N)");
                rammasser = Console.ReadLine();
            }

            if (rammasser.ToUpper() == "O")
            {
                int indexObj = -1;
                while (indexObj < 0 || indexObj >= compteurObj)
                {
                    Console.WriteLine("Quel objet voulez-vous rammasser ? (Donnez l'index de la liste)");
                    string tmp = Console.ReadLine();
                    int.TryParse(tmp, out indexObj);
                    if (indexObj < 0 || indexObj >= compteurObj)
                    {
                        Console.WriteLine("Objet introuvable !");
                    };
                }

                ObjectAction.InteractionObjectBehavior = personage.GetInteractionObjectBehavior();
                ObjectAction.Object = personage.GetPosition().objects.ElementAt(indexObj);
            }
        }

        private void AutomaticCollectObject(PersonageAbstract personage)
        {
            // Rammasser objet si c'est objectif
            List<GoalObject> listObjectifObjet = new List<GoalObject>();
            foreach (var item in personage.GetGoals().Where(x => x is GoalObject))
            {
                listObjectifObjet.Add((GoalObject)item);
            }

            if (listObjectifObjet.Exists(x => personage.GetPosition().objects.Contains(x.getObject())))
            {
                ObjectItemAbstract obj = listObjectifObjet.Where(x => personage.GetPosition().objects.Contains(x.getObject())).First().getObject();

                ObjectAction.InteractionObjectBehavior = personage.GetInteractionObjectBehavior();
                ObjectAction.Object = personage.GetPosition().objects.Where(x => x == obj).First();
            }

            Console.WriteLine("\n");
        }

        private void ManualMove(int compteurDep, PersonageAbstract personage)
        {
            int indexDep = -1;
            while (indexDep < 0 || indexDep >= compteurDep)
            {
                Console.WriteLine("Ou voulez vous aller ? (Donnez l'index de la liste des déplacement possible)");
                string tmp = Console.ReadLine();
                int.TryParse(tmp, out indexDep);
                if (indexDep < 0 || indexDep >= compteurDep)
                {
                    Console.WriteLine("Déplacement impossible !");
                };
            }

            MoveAction.MoveBehavior = personage.GetMoveBehavior();
            MoveAction.Destination = personage.GetPosition().links.ElementAt(indexDep);
        }

        private void AutomaticMove(PersonageAbstract personage)
        {
            Random random = new Random();
            int indexRandom = random.Next(0, personage.GetPosition().links.Count());

            MoveAction.MoveBehavior = personage.GetMoveBehavior();
            MoveAction.Destination = personage.GetPosition().links.ElementAt(indexRandom);
        }

        private void AnalyseSituation(PersonageAbstract personage, EnvironmentAbstract gameEnvironment)
        {
            ObjectAction = new ObjectAction();
            MoveAction = new MoveAction();

            Console.WriteLine("///////////////////////////////////");
            Console.WriteLine("//\t\t" + personage.GetName() + "\t\t//");
            Console.WriteLine("///////////////////////////////////");
            Console.WriteLine(personage.Display());

            //*********************************************************//
            //          Visibilité                                     //
            //*********************************************************//
            // 1) check si perso à un objet visibilité
            // 2) Récupérer toute les zones visible
            // 3) Afficher la carte en passant en parametre les zones visibles
            List<ZoneAbstract> zoneVisible = new List<ZoneAbstract>();
            // 1
            int visibilite = personage.GetDefaultVisibility();
            List<ObjectItemAbstract> objVisibilite = personage.GetObjects().Where(x => x is Visibility).ToList();
            foreach (var item in objVisibilite)
            {
                visibilite += ((Visibility)item).GetVisibilite();
            }
            Console.WriteLine(" - Visibilite : " + visibilite + "\n");
            // 2
            GetVisibilityZone(personage.GetPosition(), visibilite, 0,  zoneVisible, personage.GetPosition());
            // 3
            gameEnvironment.DisplayEnvironmentWithVisibility(personage, zoneVisible);

            //*********************************************************//
            //          Action                                         //
            //*********************************************************//

            // Affichage des informations sur la case actuelle
            StringBuilder infos = new StringBuilder();
            infos.Append("//////////////////////////////////////\n")
                 .Append("//   Action Possible :              //\n")
                 .Append("//////////////////////////////////////\n");

            Console.WriteLine(infos);
            infos = new StringBuilder();

            //*********************************************************//
            //          Objet(s) disponible sur la case                //
            //*********************************************************//
            if (personage.GetPosition().objects.Count() > 0)
            {
                int compteurObj = 0;
                infos.Append("Ramasser Objet :\n");
                foreach (var item in personage.GetPosition().objects)
                {
                    infos.Append("\t - ").Append(item.GetName()).Append(" (").Append(compteurObj).Append(")\n");
                    compteurObj++;
                }
                infos.Append("\n\n");

                Console.WriteLine(infos);

                if (ExecutionMode == ExecutionModeEnum.automatic)
                {
                    AutomaticCollectObject(personage);
                }
                else if (ExecutionMode == ExecutionModeEnum.manual)
                {
                    ManualCollectObject(compteurObj, personage);
                }
            }

            //*********************************************************//
            //          Déplacemment possible                          //
            //*********************************************************//
            infos = new StringBuilder();
            infos.Append("Se déplacer sur :\n");
            int compteurDep = 0;
            foreach (var item in personage.GetPosition().links)
            {
                infos.Append("\t - ").Append(item.Afficher()).Append(" (").Append(compteurDep).Append(")\n");
                compteurDep++;
            }
            infos.Append("\n\n");
            Console.WriteLine(infos.ToString());

            if (ExecutionMode == ExecutionModeEnum.automatic)
            {
                AutomaticMove(personage);
            }
            else if (ExecutionMode == ExecutionModeEnum.manual)
            {
                ManualMove(compteurDep, personage);
            }
        }

        private void Execution(PersonageAbstract personage, EnvironmentAbstract gameEnvironment)
        {
            if(ObjectAction.Object != null)
            {
                // Ajout de l'objet
                personage.SetObject(ObjectAction.Object);
                Console.WriteLine("\n " + ObjectAction.InteractionObjectBehavior.CollectObject() + " : " + ObjectAction.Object.Display() + "\n");

                // Tester si le personnage à rammasser son objectif
                if (((GoalObject)personage.GetGoals().Where(x => x is GoalObject).First()).getObject() == ObjectAction.Object)
                {
                    Console.WriteLine("\n GG ! Objectif completed : " + ObjectAction.Object.GetName() + "\n");
                    ((GoalObject)personage.GetGoals().Where(x => x is GoalObject).First()).SetCompleted(true);
                }
            }

            // Modifier Position
            personage.SetPosition(MoveAction.Destination);
            Console.WriteLine("\n " + MoveAction.MoveBehavior.Move() + "\n");
            
            // Tester si le personnage est arrivé à destination
            if (((GoalPosition)personage.GetGoals().Where(x => x is GoalPosition).First()).getPosition() == MoveAction.Destination
                && personage.GetGoals().Where(x => x is GoalObject).First().GoalIsCompleted())
            {
                Console.WriteLine("\n GG ! Objectif completed : " + MoveAction.Destination.Afficher() + "\n");
                ((GoalPosition)personage.GetGoals().Where(x => x is GoalPosition).First()).SetCompleted(true);
            }
        }

        private void Update(PersonageAbstract personage, EnvironmentAbstract gameEnvironment)
        {
            // Tester si le perso est négatif ou pas
            // Si oui mettre son status à KO sinon décrémenter sa vie
            if (personage.GetPv() <= 0)
            {
                personage.SetKo(true);
            }
            else
            {
                // Décrémenter la vie du personnage
                personage.SetPv(personage.GetPv() - 1);
            }

            if (ObjectAction.Object != null)
            {
                // Supprimer l'objet de l'environnement
                gameEnvironment.RemoveObject(ObjectAction.Object);
            }

            // Supprimer le personnage de la zone d'environnement
            gameEnvironment.RemovePersonage(personage);
            gameEnvironment.AddPersonageInZone(personage, MoveAction.Destination);

            
        }

        public void launch(GameManagementAbstract gameManagement, EnvironmentAbstract gameEnvironment)
        {
            int compteur = 0;
            while (gameManagement.Personages.Where(x => x.GetGoals().Where(y => y.GoalIsCompleted()).Count() == x.GetGoals().Count()).Count() <= 0
                    && gameManagement.Personages.Where(x => x.GetKo()).Count() <= 1)
            {
                Console.WriteLine("///////////////////////////////////");
                Console.WriteLine("//\t  Tour " + compteur + "\t\t//");
                Console.WriteLine("///////////////////////////////////");
                Console.WriteLine("\n");

                foreach (var item in gameManagement.Personages.Where(x=>!x.GetKo()))
                {
                    // Pour chaque personnage : AnalyseSituation()
                    AnalyseSituation(item, gameEnvironment);
                    // Execution
                    Execution(item, gameEnvironment);
                    // Pour chaque objet : MiseAJour()
                    Update(item, gameEnvironment);
                }
                compteur++;
            }

            if (gameManagement.Personages.Where(x => x.GetGoals().Where(y => y.GoalIsCompleted()).Count() == x.GetGoals().Count()).Count() > 0)
            {
                PersonageAbstract winner = gameManagement.Personages.Where(x => x.GetGoals().Where(y => y.GoalIsCompleted()).Count() == x.GetGoals().Count()).First();

                Console.WriteLine("\n\n");
                Console.WriteLine("///////////////////////////////////////////////////");
                Console.WriteLine("//\t  Le gagnant est " + winner.GetName() + " ! \t\t//");
                Console.WriteLine("///////////////////////////////////////////////////");
                Console.WriteLine("\n");
                Console.WriteLine(winner.Display());
            }
            else if (gameManagement.Personages.Where(x => !x.GetKo()).Count() > 0)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("////////////////////////////////////////////");
                Console.WriteLine("//\t  The winner is " + gameManagement.Personages.Where(x => !x.GetKo()).First().GetName() + " ! \t\t//");
                Console.WriteLine("////////////////////////////////////////////");
                Console.WriteLine("\n");
                Console.WriteLine("Félicitation vous etes le seul survivant !");
            }
            else
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("////////////////////////////////////////////");
                Console.WriteLine("//\t  Vous etes tous mort dûrant le même tour ! \t\t//");
                Console.WriteLine("////////////////////////////////////////////");
                Console.WriteLine("\n");
                Console.WriteLine("Personne n'a gagné !");
            }
        }
    }
}
