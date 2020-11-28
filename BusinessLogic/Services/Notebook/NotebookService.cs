namespace BusinessLogic.Services.Notebook
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using BusinessLogic.Interfaces.Notebook;
    using BusinessLogic.Models.Notebook;
    using DataAccessLayer.Interfaces;
    using DataAccessLayer.Models.Notebook;

    public class NotebookService : INotebookService
    {
        private readonly IAplicationDbContext _iAplicationDbContext;
        private readonly IMapper _iMapper;

        public NotebookService(
            IAplicationDbContext iAplicationDbContext,
            IMapper iMapper)
        {
            _iAplicationDbContext = iAplicationDbContext;
            _iMapper = iMapper;
        }

        public void AddPerson(PersonDto personDto)
        {
            var p = _iMapper.Map<PersonEntity>(personDto);
            _iAplicationDbContext.Persons.Add(p);
        }

        public List<PersonDto> GetPersons()
        {
            var t = _iAplicationDbContext.Persons.ToList();
            return null;
        }
    }
}
