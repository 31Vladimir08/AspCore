namespace BusinessLogic.Models.Notebook.Entities
{
    public class EmailDto
    {
        public long Id { get; set; }

        public string EmailAddress { get; set; }

        public long PersonId { get; set; }

        public PersonDto Person { get; set; }
    }
}
