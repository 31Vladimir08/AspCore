namespace BusinessLogic.Models.Notebook.Entities
{
    using System;
    using System.Collections.Generic;

    public class PersonDto
    {
        public long Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Organization { get; set; }

        public List<EmailDto> Emails { get; set; }

        public List<PhoneDto> Phones { get; set; }

        public List<SkypeDto> SkypeContacts { get; set; }
    }
}
