namespace DataAccessLayer.Models.Notebook
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PersonEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(200)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Patronymic { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(200)]
        public string Organization { get; set; }

        public List<EmailEntity> Emails { get; set; }

        public List<PhoneEntity> Phones { get; set; }

        public List<SkypeEntity> SkypeContacts { get; set; }
    }

    public class PersonEntityConfig : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.HasIndex(u => u.Surname);
            builder.HasIndex(u => u.Organization);
        }
    }
}
