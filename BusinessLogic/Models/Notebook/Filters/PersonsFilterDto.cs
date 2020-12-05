namespace BusinessLogic.Models.Notebook.Filters
{
    public class PersonsFilterDto
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public DateRange DateOfBirth { get; set; }

        public string Organization { get; set; }

        public string Email { get; set; }

        public string PhoneNumbers { get; set; }

        public string SkypeLogin { get; set; }
    }
}
