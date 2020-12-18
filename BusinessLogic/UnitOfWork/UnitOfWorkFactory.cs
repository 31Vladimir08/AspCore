namespace BusinessLogic.UnitOfWork
{
    using BusinessLogic.Interfaces.UnitOfWork;
    using DataAccessLayer;

    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork(new MsSqlDbContext());
        }
    }
}
