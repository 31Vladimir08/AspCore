namespace BusinessLogic.UnitOfWork
{
    using BusinessLogic.Interfaces.UnitOfWork;

    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork();
        }
    }
}
