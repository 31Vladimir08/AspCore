namespace BusinessLogic.Interfaces
{
    using StructureMap;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IUnitOfWork
    {
        void Commit();

        void Rollback();
    }
}
