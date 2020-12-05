namespace BusinessLogic.Interfaces.Notebook
{
    using System.Collections.Generic;
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;

    public interface INotebookService : IService
    {
        List<PersonDto> GetPersons(PersonsFilterDto personsFilterDto);

        void AddPerson(PersonDto personDto);
    }
}
