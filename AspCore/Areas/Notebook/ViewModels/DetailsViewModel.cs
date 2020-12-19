namespace AspCore.Areas.Notebook.ViewModels
{
    using System.Collections.Generic;
    using AspCore.Models.Notebook.Entities;

    public class DetailsViewModel
    {
        public DetailsViewModel()
        {
            Person = new PersonUi();
            Email = new EmailUi();
            Phone = new PhoneUi();
            SkypePerson = new SkypeUi();

            Emails = new List<EmailUi>();
            Phones = new List<PhoneUi>();
            Skype = new List<SkypeUi>();
        }

        public PersonUi Person { get; set; }

        public EmailUi Email { get; set; }

        public PhoneUi Phone { get; set; }

        public SkypeUi SkypePerson { get; set; }

        public IEnumerable<EmailUi> Emails { get; set; }

        public IEnumerable<PhoneUi> Phones { get; set; }

        public IEnumerable<SkypeUi> Skype { get; set; }
    }
}
