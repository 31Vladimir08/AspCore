namespace DataAccessLayer.Models.Notebook
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PersonEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string Organization { get; set; }

        public List<PhotoEntity> Photos { get; set; }

        public List<EmailEntity> Emails { get; set; }

        public List<PhoneEntity> Phones { get; set; }

        public List<SkypeEntity> SkypeContacts { get; set; }
    }
}
