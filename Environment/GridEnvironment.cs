using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SimulationJeu.ObjectItem;
using SimulationJeu.Personage;
using SimulationJeu.Zone;

namespace SimulationJeu.Environment
{
    public class GridEnvironment : EnvironmentAbstract
    {
        public GridEnvironment()
        {
            Zones = new ObservableCollection<ZoneAbstract>();
        }

        public override void AddZone(int x, int y, int z)
        {
            Zones.Add(new Square(x, y, z));
        }

        public override void AddBidirectionalLink(ZoneAbstract originZone, ZoneAbstract targetZone)
        {
            originZone.AddLink(targetZone);
            targetZone.AddLink(originZone);
        }

        public override void AddUnidirectionalLink(ZoneAbstract originZone, ZoneAbstract targetZone)
        {
            originZone.AddLink(targetZone);
        }

        public override ZoneAbstract GetZone(int x, int y, int z)
        {
            return Zones.Where(a=>a.X == x && a.Y == y && a.Z == z).FirstOrDefault();
        }

        public override void LoadObject(List<ObjectItemAbstract> objs)
        {
            foreach (var item in Zones)
                foreach (var obj in objs.Where(x => x.GetZone() == item))
                    item.objects.Add(obj);
        }

        public override void LoadPersonage(List<PersonageAbstract> personages)
        {
            foreach (var item in Zones)
                foreach (var perso in personages.Where(x => x.GetPosition() == item))
                    item.personages.Add(perso);
        }

        public override void RemoveObject(ObjectItemAbstract obj)
        {
            Zone.ZoneAbstract zone = Zones.Where(x => x.objects.Contains(obj)).FirstOrDefault();
            if (zone != null)
            {
                zone.objects.Remove(obj);
            }
        }

        public override void RemovePersonage(PersonageAbstract perso)
        {
            Zone.ZoneAbstract zone = Zones.Where(x => x.personages.Contains(perso)).FirstOrDefault();
            if (zone != null)
            {
                zone.personages.Remove(perso);
            }
        }

        public override void AddPersonageInZone(PersonageAbstract perso, ZoneAbstract position)
        {
            Zone.ZoneAbstract zone = Zones.Where(x => x == position).FirstOrDefault();
            zone.personages.Add(perso);
        }

        public override void DisplayEnvironment(PersonageAbstract perso)
        {
            Console.WriteLine("////////////////////////////////////////////////");
            Console.WriteLine("//                Plateau :                   //");
            Console.WriteLine("////////////////////////////////////////////////");
            Console.WriteLine("\n");

            StringBuilder str1 = new StringBuilder("\t   ");
            StringBuilder str2 = new StringBuilder("\t Y1");
            StringBuilder str3 = new StringBuilder("\t   ");

            StringBuilder abscisse = new StringBuilder("\t    ");
            for (int a = 0; a < Zones.Select(x => x.X).Max(); a++)
            {
                abscisse.Append("X").Append(a + 1).Append("   ");
            }
            abscisse.Append("\n");
            Console.WriteLine(abscisse.ToString());

            int y = 1;
            foreach (var item in Zones.OrderBy(o => o.Y))
            {
                if (y != item.Y)
                {
                    Console.WriteLine(str1.ToString());
                    Console.WriteLine(str2.ToString());
                    Console.WriteLine(str3.ToString());

                    str1 = new StringBuilder("\t   ");
                    str2 = new StringBuilder("\t Y" + (y+1));
                    str3 = new StringBuilder("\t   ");
                }

                // gauche
                if (item.links.Where(x => x.X == item.X - 1 && x.Y == item.Y).Count() == 0)
                {
                    str1.Append("|");
                    str2.Append("|");
                    str3.Append("|");
                }
                else
                {
                    str1.Append("  ");
                    str2.Append("  ");
                    str3.Append("  ");
                }

                // haut
                if (item.links.Where(x => x.Y == item.Y - 1 && x.X == item.X).Count() == 0)
                {
                    str1.Append("¨¨¨");
                }
                else
                {
                    str1.Append("   ");
                }

                // Milieu
                if (item == perso.GetPosition())
                {
                    str2.Append(" P ");
                }
                else
                {
                    str2.Append("   ");
                }

                // bas
                if (item.links.Where(x => x.Y == item.Y + 1 && x.X == item.X).Count() == 0)
                {
                    str3.Append("___");
                }
                else
                {
                    str3.Append("   ");
                }

                // droite
                if (item.links.Where(x => x.X == item.X + 1 && x.Y == item.Y).Count() == 0)
                {
                    str1.Append("|");
                    str2.Append("|");
                    str3.Append("|");
                }

                y = item.Y;
            }
            Console.WriteLine(str1.ToString());
            Console.WriteLine(str2.ToString());
            Console.WriteLine(str3.ToString());
            Console.WriteLine("\n\n");
        }

        public override void DisplayEnvironmentWithPersonagesAndObjects()
        {
            Console.WriteLine("////////////////////////////////////////////////");
            Console.WriteLine("//                Plateau :                   //");
            Console.WriteLine("////////////////////////////////////////////////");
            Console.WriteLine("\n");
            Console.WriteLine("O => Objet(s)");
            Console.WriteLine("P => Personnage(s)");
            Console.WriteLine("A => Objet Et Personnage(s)"); 
            Console.WriteLine("\n");

            StringBuilder str1 = new StringBuilder("\t   ");
            StringBuilder str2 = new StringBuilder("\t Y1");
            StringBuilder str3 = new StringBuilder("\t   ");

            StringBuilder abscisse = new StringBuilder("\t    ");
            for (int a = 0; a < Zones.Select(x => x.X).Max(); a++)
            {
                abscisse.Append("X").Append(a + 1).Append("   ");
            }
            abscisse.Append("\n");
            Console.WriteLine(abscisse.ToString());

            int y = 1;
            foreach (var item in Zones.OrderBy(o => o.Y))
            {
                if (y != item.Y)
                {
                    Console.WriteLine(str1.ToString());
                    Console.WriteLine(str2.ToString());
                    Console.WriteLine(str3.ToString());

                    str1 = new StringBuilder("\t   ");
                    str2 = new StringBuilder("\t Y" + (y + 1));
                    str3 = new StringBuilder("\t   ");
                }

                // gauche
                if (item.links.Where(x => x.X == item.X - 1 && x.Y == item.Y).Count() == 0)
                {
                    str1.Append("|");
                    str2.Append("|");
                    str3.Append("|");
                }
                else
                {
                    str1.Append("  ");
                    str2.Append("  ");
                    str3.Append("  ");
                }

                // haut
                if (item.links.Where(x => x.Y == item.Y - 1 && x.X == item.X).Count() == 0)
                {
                    str1.Append("¨¨¨");
                }
                else
                {
                    str1.Append("   ");
                }

                // Milieu
                if (item.objects.Count() > 0 && item.personages.Count() == 0)
                {
                    str2.Append(" O ");
                }
                else if (item.personages.Count() > 0 && item.objects.Count() == 0)
                {
                    str2.Append(" P ");
                }
                else if (item.objects.Count() == 0 && item.personages.Count() == 0)
                {
                    str2.Append("   ");
                }
                else
                {
                    str2.Append(" A ");
                }

                // bas
                if (item.links.Where(x => x.Y == item.Y + 1 && x.X == item.X).Count() == 0)
                {
                    str3.Append("___");
                }
                else
                {
                    str3.Append("   ");
                }

                // droite
                if (item.links.Where(x => x.X == item.X + 1 && x.Y == item.Y).Count() == 0)
                {
                    str1.Append("|");
                    str2.Append("|");
                    str3.Append("|");
                }

                y = item.Y;
            }
            Console.WriteLine(str1.ToString());
            Console.WriteLine(str2.ToString());
            Console.WriteLine(str3.ToString());
            Console.WriteLine("\n\n");
        }

        public override void DisplayEnvironmentWithVisibility(PersonageAbstract perso, List<ZoneAbstract> zoneVisible)
        {
            Console.WriteLine("////////////////////////////////////////////////");
            Console.WriteLine("//                Plateau :                   //");
            Console.WriteLine("////////////////////////////////////////////////");
            Console.WriteLine("\n");
            Console.WriteLine("O => Objet(s)");
            Console.WriteLine("P => Personnage(s)");
            Console.WriteLine("A => Objet Et Personnage(s)");
            Console.WriteLine("\n");

            StringBuilder str1 = new StringBuilder("\t   ");
            StringBuilder str2 = new StringBuilder("\t Y1");
            StringBuilder str3 = new StringBuilder("\t   ");

            StringBuilder abscisse = new StringBuilder("\t    ");
            for (int a = 0; a < Zones.Select(x => x.X).Max(); a++)
            {
                abscisse.Append("X").Append(a + 1).Append("   ");
            }
            abscisse.Append("\n");
            Console.WriteLine(abscisse.ToString());

            int y = 1;
            foreach (var item in Zones.OrderBy(o => o.Y))
            {
                if (y != item.Y)
                {
                    Console.WriteLine(str1.ToString());
                    Console.WriteLine(str2.ToString());
                    Console.WriteLine(str3.ToString());

                    str1 = new StringBuilder("\t   ");
                    str2 = new StringBuilder("\t Y" + (y + 1));
                    str3 = new StringBuilder("\t   ");
                }

                // gauche
                if (item.links.Where(x => x.X == item.X - 1 && x.Y == item.Y).Count() == 0)
                {
                    str1.Append("|");
                    str2.Append("|");
                    str3.Append("|");
                }
                else
                {
                    str1.Append("  ");
                    str2.Append("  ");
                    str3.Append("  ");
                }

                // haut
                if (item.links.Where(x => x.Y == item.Y - 1 && x.X == item.X).Count() == 0)
                {
                    str1.Append("¨¨¨");
                }
                else
                {
                    str1.Append("   ");
                }

                // Milieu
                if (item == perso.GetPosition() && zoneVisible.Where(x=>x == item && x.objects.Count() > 0).Count() == 0)
                {
                    str2.Append(" P ");
                }
                else if (item == perso.GetPosition() && zoneVisible.Where(x => x == item && x.objects.Count() > 0).Count() > 0)
                {
                    str2.Append(" A ");
                }
                else if (zoneVisible.Where(x => x == item && x.objects.Count() > 0).Count() > 0)
                {
                    str2.Append(" O ");
                }
                else
                {
                    str2.Append("   ");
                }

                // bas
                if (item.links.Where(x => x.Y == item.Y + 1 && x.X == item.X).Count() == 0)
                {
                    str3.Append("___");
                }
                else
                {
                    str3.Append("   ");
                }

                // droite
                if (item.links.Where(x => x.X == item.X + 1 && x.Y == item.Y).Count() == 0)
                {
                    str1.Append("|");
                    str2.Append("|");
                    str3.Append("|");
                }

                y = item.Y;
            }
            Console.WriteLine(str1.ToString());
            Console.WriteLine(str2.ToString());
            Console.WriteLine(str3.ToString());
            Console.WriteLine("\n\n");
        }
    }
}
