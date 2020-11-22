namespace MapStructure.MapRegistry
{
    using BusinessLogic.Interfaces;
    using BusinessLogic.Interfaces.Notebook;
    using BusinessLogic.Services.Notebook;
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
