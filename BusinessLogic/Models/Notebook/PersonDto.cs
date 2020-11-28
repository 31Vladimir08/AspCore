namespace BusinessLogic.Models.Notebook
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PersonDto
    {
        public long Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string Organization { get; set; }

        public List<PhotoDto> Photos { get; set; }

        public List<EmailDto> Emails { get; set; }

        public List<PhoneDto> Phones { get; set; }

        public List<SkypeDto> SkypeContacts { get; set; }
    }
}
