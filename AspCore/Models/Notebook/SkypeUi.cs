namespace AspCore.Models.Notebook
{
    public class SkypeUi
    {
        public long Id { get; set; }

        public string SkypeLogin { get; set; }

        public long PersonId { get; set; }

        public PersonUi Person { get; set; }
    }
}
