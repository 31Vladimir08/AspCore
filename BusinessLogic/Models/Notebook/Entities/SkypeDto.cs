namespace BusinessLogic.Models.Notebook.Entities
{
    public class SkypeDto
    {
        public long Id { get; set; }

        public string SkypeLogin { get; set; }

        public long PersonId { get; set; }

        public PersonDto Person { get; set; }
    }
}
