namespace DataAccessLayer.Models.Notebook
{
    public class SkypeEntity
    {
        public long Id { get; set; }

        public string SkypeLogin { get; set; }

        public long PersonId { get; set; }

        public PersonEntity Person { get; set; }
    }
}
