namespace MapStructure.MapRegistry
{
    using BusinessLogic.Interfaces;
    using BusinessLogic.Interfaces.UnitOfWork;
    using BusinessLogic.UnitOfWork;
    using StructureMap;

    public class StructuremapUnitOfWorkRegistry : Registry
    {
        public StructuremapUnitOfWorkRegistry()
        {
            For<IUnitOfWork>().Use<UnitOfWork>();
            For<IUnitOfWorkFactory>().Use<UnitOfWorkFactory>();
        }
    }
}
