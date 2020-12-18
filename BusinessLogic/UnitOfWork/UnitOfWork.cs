namespace BusinessLogic.UnitOfWork
{
    using System;
    using BusinessLogic.Interfaces.Services;
    using BusinessLogic.Interfaces.UnitOfWork;
    using DataAccessLayer.Interfaces;
    using Microsoft.EntityFrameworkCore.Storage;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContextTransaction _iTransaction;

        public UnitOfWork(IAplicationDbContext aplicationDbContext)
        {
            Context = aplicationDbContext;
            _iTransaction = Context.Database.BeginTransaction();
        }

        public IAplicationDbContext Context { get; private set; }

        public void Commit()
        {
            try
            {
                Context.SaveChanges();
                _iTransaction.Commit();
            }
            catch (Exception e)
            {
                _iTransaction.Rollback();
                throw e;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Rollback()
        {
            _iTransaction.Rollback();
        }
    }
}
