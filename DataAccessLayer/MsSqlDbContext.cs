﻿namespace DataAccessLayer
{
    using DataAccessLayer.Interfaces;
    using DataAccessLayer.Models.Notebook;
    using Microsoft.EntityFrameworkCore;

    public class MsSqlDbContext : DbContext, IAplicationDbContext
    {
        public DbSet<EmailEntity> Emails { get; set; }

        public DbSet<PersonEntity> Persons { get; set; }

        public DbSet<PhoneEntity> Phones { get; set; }

        public DbSet<SkypeEntity> Skype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ComplexArchitectureDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmailEntityConfig());
            modelBuilder.ApplyConfiguration(new PersonEntityConfig());
            modelBuilder.ApplyConfiguration(new PhoneEntityConfig());
            modelBuilder.ApplyConfiguration(new SkypeEntityConfig());
        }
    }
}
