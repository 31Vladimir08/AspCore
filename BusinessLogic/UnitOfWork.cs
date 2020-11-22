namespace BusinessLogic
{
    using BusinessLogic.Interfaces;
    using DataAccessLayer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAplicationDbContext _iAplicationDbContext;
        public UnitOfWork(
            IAplicationDbContext iAplicationDbContext)
        {
            _iAplicationDbContext = iAplicationDbContext;
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Create()
        {
            var t = _iAplicationDbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _iAplicationDbContext.Dispose();
        }
    }
}
