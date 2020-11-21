namespace DataAccessLayer.Models.Notebook
{
    public class PhotoEntity
    {
        public long Id { get; set; }

        public byte[] Image1 { get; set; }

        public long PersonId { get; set; }

        public PersonEntity Person { get; set; }
    }
}
