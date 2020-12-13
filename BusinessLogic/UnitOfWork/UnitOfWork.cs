namespace BusinessLogic.UnitOfWork
{
    using AutoMapper;
    using BusinessLogic.Interfaces;
    using BusinessLogic.Interfaces.Services;
    using BusinessLogic.Interfaces.UnitOfWork;
    using DataAccessLayer;
    using DataAccessLayer.Interfaces;
    using Microsoft.EntityFrameworkCore.Storage;
    using StructureMap;
    using System;
    using System.Linq;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAplicationDbContext _iAplicationDbContext;

        private IDbContextTransaction _iTransaction;

        public UnitOfWork()
        {
            _iAplicationDbContext = new MsSqlDbContext();
            _iTransaction = _iAplicationDbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _iAplicationDbContext.SaveChanges();
            _iTransaction.Commit();
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
            var type = typeof(T);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.Name != type.Name)
                .FirstOrDefault();
            
            //var obj = Type.GetType(types.Name);
            //var t = types.GetConstructor(new Type[] { });
            var c = types.GetConstructors().FirstOrDefault();
            var instance = Activator.CreateInstance(types, typeof(IAplicationDbContext), typeof(IMapper));
            return null;
        }
    }
}
