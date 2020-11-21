namespace AspCore.Models.Notebook
{
    public class EmailUi
    {
        public long Id { get; set; }

        public string EmailAddress { get; set; }

        public long PersonId { get; set; }

        public PersonUi Person { get; set; }
    }
}
