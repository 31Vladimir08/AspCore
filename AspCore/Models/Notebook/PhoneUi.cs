namespace AspCore.Models.Notebook
{
    public class PhoneUi
    {
        public long Id { get; set; }

        public string PhoneNumber { get; set; }

        public long PersonId { get; set; }

        public PersonUi Person { get; set; }
    }
}
