namespace DataAccessLayer.Interfaces
{
    using DataAccessLayer.Models.Notebook;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using System;

    public interface IAplicationDbContext : IDisposable
    {
        DbSet<EmailEntity> Emails { get; set; }

        DbSet<PersonEntity> Persons { get; set; }

        DbSet<PhoneEntity> Phones { get; set; }

        DbSet<PhotoEntity> Photos { get; set; }

        DbSet<SkypeEntity> Skype { get; set; }

        DatabaseFacade Database { get; }
    }
}
