namespace BusinessLogic.Interfaces.UnitOfWork
{
    using BusinessLogic.Interfaces.Services;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        T GetService<T>() where T : class, IService;

        void Commit();

        void Rollback();
    }
}
