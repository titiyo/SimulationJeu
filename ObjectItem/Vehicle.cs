using System.Text;

namespace SimulationJeu.ObjectItem
{
    class Vehicle : ObjectItemAbstract
    {
        public Vehicle(string name, Zone.ZoneAbstract position)
            : base(name, position)
        {
        }

        public override string Display()
        {
            StringBuilder obj = new StringBuilder();
            obj.Append(Name).Append(" (Vehicule)\n");
            if (Position != null)
                obj.Append(" - Position : ").Append(Position.Afficher());

            return obj.ToString();
        }
    }
}
