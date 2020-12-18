namespace BusinessLogic.Interfaces.UnitOfWork
{
    using DataAccessLayer.Interfaces;
    using System;

    public interface IUnitOfWork : IDisposable
    {
        IAplicationDbContext Context { get; }

        void Commit();

        void Rollback();
    }
}
