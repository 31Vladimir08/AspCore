namespace AspCore.Areas.Notebook.ViewModels
{
    using System.Collections.Generic;
    using AspCore.Models.Notebook.Entities;

    public class ContactsViewModel
    {
        public PersonUi Person { get; set; }

        public IEnumerable<EmailUi> Emails { get; set; }

        public IEnumerable<PhoneUi> Phones { get; set; }

        public IEnumerable<SkypeUi> Skype { get; set; }
    }
}
