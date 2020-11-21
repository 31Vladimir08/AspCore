namespace DataAccessLayer.Models.Notebook
{
    public class PhoneEntity
    {
        public long Id { get; set; }

        public string PhoneNumber { get; set; }

        public long PersonId { get; set; }

        public PersonEntity Person { get; set; }
    }
}
