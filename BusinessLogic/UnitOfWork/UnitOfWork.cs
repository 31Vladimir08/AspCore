namespace BusinessLogic.UnitOfWork
{
    using System;
    using BusinessLogic.Interfaces.UnitOfWork;
    using DataAccessLayer.Interfaces;
    using Microsoft.EntityFrameworkCore.Storage;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAplicationDbContext _aplicationDbContext;
        private readonly IDbContextTransaction _iTransaction;

        public UnitOfWork(IAplicationDbContext aplicationDbContext)
        {
            _aplicationDbContext = aplicationDbContext;
            _iTransaction = _aplicationDbContext.Database.BeginTransaction();
        }

        public IAplicationDbContext Context
        {
            get => _aplicationDbContext;
        }

        public void Commit()
        {
            try
            {
                _aplicationDbContext.SaveChanges();
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
