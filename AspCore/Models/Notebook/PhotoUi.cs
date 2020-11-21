namespace AspCore.Models.Notebook
{
    public class PhotoUi
    {
        public long Id { get; set; }

        public byte[] Image1 { get; set; }

        public long PersonId { get; set; }

        public PersonUi Person { get; set; }
    }
}
