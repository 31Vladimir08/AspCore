namespace MapStructure.MapRegistry
{
    using DataAccessLayer;
    using DataAccessLayer.Interfaces;
    using StructureMap;

    public class StructuremapContextRegistry : Registry
    {
        public StructuremapContextRegistry()
        {
            For<IAplicationDbContext>().Use<AplicationDbContext>();
        }
    }
}
