using System.Text;

namespace SimulationJeu.ObjectItem
{
    class Visibility : ObjectItemAbstract
    {
        int BonusVisibilite;

        public Visibility(string name, Zone.ZoneAbstract position)
            : base(name, position)
        {
            BonusVisibilite = 1;
        }

        public override string Display()
        {
            StringBuilder obj = new StringBuilder();
            obj.Append(Name).Append(" (Visibilite +"+ BonusVisibilite +")\n");
            if (Position != null)
                obj.Append(" - Position : ").Append(Position.Afficher());

            return obj.ToString();
        }

        public override string ToString()
        {
            StringBuilder obj = new StringBuilder();
            obj.Append(Name).Append(" (Visibilite +)"+BonusVisibilite+"\n");
            return obj.ToString();
        }

        public int GetVisibilite()
        {
            return BonusVisibilite;
        }

        public void SetVisibilite(int bonusVisibilite)
        {
            BonusVisibilite = bonusVisibilite;
        }
    }
}
