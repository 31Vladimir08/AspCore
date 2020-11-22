namespace BusinessLogic.Services.Notebook
{
    using BusinessLogic.Interfaces;
    using BusinessLogic.Interfaces.Notebook;
    using BusinessLogic.Models.Notebook;
    using DataAccessLayer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NotebookService : INotebookService
    {
        private readonly IAplicationDbContext _iAplicationDbContext;

        public NotebookService(IAplicationDbContext iAplicationDbContext)
        {
            _iAplicationDbContext = iAplicationDbContext;
        }
        public List<PersonDto> GetPersons()
        {
            return null;
        }
    }
}
