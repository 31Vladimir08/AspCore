﻿namespace DataAccessLayer.Interfaces
{
    using DataAccessLayer.Models.Notebook;
    using Microsoft.EntityFrameworkCore;

    public interface IAplicationDbContext
    {
        DbSet<EmailEntity> EmailEntities { get; set; }

        DbSet<PersonEntity> PersonEntities { get; set; }

        DbSet<PhoneEntity> PhoneEntities { get; set; }

        DbSet<PhotoEntity> PhotoEntities { get; set; }

        DbSet<SkypeEntity> SkypeEntities { get; set; }
    }
}
