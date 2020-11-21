namespace BusinessLogic
{
    using BusinessLogic.Interfaces;
    using StructureMap;
    using System;

    public class UnitOfWork : IUnitOfWork
    {
        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
