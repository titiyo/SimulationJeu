using System.Text;

namespace SimulationJeu.ObjectItem
{
    class Treasure : ObjectItemAbstract
    {
        public Treasure(string name, Zone.ZoneAbstract position) 
            : base(name, position)
        {
        }

        public override string Display()
        {
            StringBuilder obj = new StringBuilder();
            obj.Append(Name).Append(" (Tresor)\n");
            if (Position != null)
                obj.Append(" - Position : ").Append(Position.Afficher());

            return obj.ToString();
        }
    }
}
