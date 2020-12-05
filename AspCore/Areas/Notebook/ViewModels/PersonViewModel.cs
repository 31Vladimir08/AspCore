namespace AspCore.Areas.Notebook.ViewModels
{
    using System.Collections.Generic;
    using AspCore.Models.Notebook;
    using AspCore.Models.Notebook.Filters;

    public class PersonViewModel
    {
        public PersonViewModel()
        {
            PersonFilter = new PersonsFilterUi();
            Persons = new List<PersonUi>();
        }

        public IEnumerable<PersonUi> Persons { get; set; }

        public PersonsFilterUi PersonFilter { get; set; }

        public PersonUi Person { get; }
    }
}
