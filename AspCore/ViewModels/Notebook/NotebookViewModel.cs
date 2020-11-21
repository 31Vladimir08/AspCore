namespace AspCore.ViewModels.Notebook
{ 
    using AspCore.Models.Notebook;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class NotebookViewModel
    {
        public IEnumerable<PersonUi> Persons { get; set; }
    }
}
