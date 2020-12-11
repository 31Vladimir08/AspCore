namespace BusinessLogic.Models.Notebook.Entities
{
    public class PhoneDto
    {
        public long Id { get; set; }

        public string PhoneNumber { get; set; }

        public long PersonId { get; set; }

        public PersonDto Person { get; set; }
    }
}
