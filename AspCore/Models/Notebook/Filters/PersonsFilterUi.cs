namespace AspCore.Models.Notebook.Filters
{
    using System.ComponentModel.DataAnnotations;
    using BusinessLogic.Models;

    public class PersonsFilterUi
    {
        public PersonsFilterUi()
        {
            DateOfBirth = new DateRange();
        }

        [MaxLength(200)]
        public string Surname { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Patronymic { get; set; }

        public DateRange DateOfBirth { get; set; }

        [MaxLength(200)]
        public string Organization { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string PhoneNumbers { get; set; }

        [MaxLength(200)]
        public string SkypeLogin { get; set; }
    }
}
