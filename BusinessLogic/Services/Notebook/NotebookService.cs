namespace BusinessLogic.Services.Notebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AutoMapper;
    using BusinessLogic.Interfaces;
    using BusinessLogic.Interfaces.Notebook;
    using BusinessLogic.Models.Notebook;
    using DataAccessLayer.Interfaces;
    using DataAccessLayer.Models.Notebook;

    public class NotebookService : INotebookService
    {
        private readonly IAplicationDbContext _iAplicationDbContext;

        public NotebookService(IAplicationDbContext iAplicationDbContext)
        {
            _iAplicationDbContext = iAplicationDbContext;
        }

        public void AddPerson(PersonDto personDto)
        {
            _iAplicationDbContext.Persons.Add(null);
        }

        public List<PersonDto> GetPersons()
        {
            var t = _iAplicationDbContext.Persons.ToList();
            return null;
        }
    }
}
