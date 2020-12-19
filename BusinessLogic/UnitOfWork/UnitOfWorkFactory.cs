namespace BusinessLogic.UnitOfWork
{
    using System;

    using BusinessLogic.Interfaces.UnitOfWork;
    using DataAccessLayer;

    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWorkFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUnitOfWork Create()
        {
            /*return (IUnitOfWork)_serviceProvider.GetService(typeof(IUnitOfWork));*/
            return new UnitOfWork(new MsSqlDbContext());
        }
    }
}
