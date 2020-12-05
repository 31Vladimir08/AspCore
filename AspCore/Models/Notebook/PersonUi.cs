namespace AspCore.Models.Notebook
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PersonUi
    {
        public long Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string Organization { get; set; }

        public List<EmailUi> Emails { get; set; }

        public List<PhoneUi> Phones { get; set; }

        public List<SkypeUi> SkypeContacts { get; set; }
    }
}
