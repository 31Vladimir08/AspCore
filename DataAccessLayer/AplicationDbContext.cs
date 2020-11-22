namespace DataAccessLayer
{
    using DataAccessLayer.Interfaces;
    using DataAccessLayer.Models.Notebook;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AplicationDbContext : DbContext, IAplicationDbContext
    {
        public DbSet<EmailEntity> Emails { get; set; }

        public DbSet<PersonEntity> Persons { get; set; }

        public DbSet<PhoneEntity> Phones { get; set; }

        public DbSet<PhotoEntity> Photos { get; set; }

        public DbSet<SkypeEntity> Skype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ComplexArchitectureDB;Trusted_Connection=True;");
        }
    }
}
