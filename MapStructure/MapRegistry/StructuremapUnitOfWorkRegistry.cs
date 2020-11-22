namespace MapStructure.MapRegistry
{
    using BusinessLogic;
    using BusinessLogic.Interfaces;
    using StructureMap;

    public class StructuremapUnitOfWorkRegistry : Registry
    {
        public StructuremapUnitOfWorkRegistry()
        {
            For<IUnitOfWork>().Use<UnitOfWork>();
        }
    }
}
