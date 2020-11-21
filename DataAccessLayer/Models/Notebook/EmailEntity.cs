namespace DataAccessLayer.Models.Notebook
{
    public class EmailEntity
    {
        public long Id { get; set; }

        public string EmailAddress { get; set; }

        public long PersonId { get; set; }

        public PersonEntity Person { get; set; }
    }
}
