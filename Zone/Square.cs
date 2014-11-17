namespace SimulationJeu.Zone
{
    public class Square : ZoneAbstract
    {
        public Square(int x, int y, int z) : base(x, y, z)
        {
        }

        public override void AddLink(ZoneAbstract targetZone)
        {
            if (!ExistingLink(targetZone))
            {
                links.Add(targetZone);
            }
        }

        public override bool ExistingLink(ZoneAbstract targetZone)
        {
            return links.Contains(targetZone);
        }
    }
}
