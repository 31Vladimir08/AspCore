namespace BusinessLogic.Interfaces
{
    using BusinessLogic.Interfaces.Services;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IUnitOfWork CreateTransaction();

        T GetService<T>() where T : class, IService;

        void Commit();

        void Rollback();
    }
}
