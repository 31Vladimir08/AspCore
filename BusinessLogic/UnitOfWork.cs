namespace BusinessLogic
{
    using BusinessLogic.Interfaces;
    using DataAccessLayer.Interfaces;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAplicationDbContext _iAplicationDbContext;

        private IDbContextTransaction _iTransaction;

        public UnitOfWork(
            IAplicationDbContext iAplicationDbContext)
        {
            _iAplicationDbContext = iAplicationDbContext;
        }

        public void Commit()
        {
            _iAplicationDbContext.SaveChanges();
            _iTransaction.Commit();
        }

        public IUnitOfWork CreateTransaction()
        {
            _iTransaction = _iAplicationDbContext.Database.BeginTransaction();
            return this;
        }

        public void Dispose()
        {
            _iAplicationDbContext.Dispose();
        }

        public void Rollback()
        {
            _iTransaction.Rollback();
        }

        public T GetService<T>() where T : class, IService
        {
            var t = typeof(T);
            return null;
        }
    }
}
