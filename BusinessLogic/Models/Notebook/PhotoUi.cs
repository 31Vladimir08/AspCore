namespace BusinessLogic.Models.Notebook
{
    public class PhotoDto
    {
        public long Id { get; set; }

        public byte[] Image1 { get; set; }

        public long PersonId { get; set; }

        public PersonDto Person { get; set; }
    }
}
