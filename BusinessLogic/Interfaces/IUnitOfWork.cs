namespace BusinessLogic.Interfaces
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Create();

        void Commit();

        void Rollback();
    }
}
