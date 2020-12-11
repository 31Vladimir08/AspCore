namespace BusinessLogic.Interfaces.Logic.Notebook
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;

    public interface INotebookLogic
    {
        Task<List<PersonDto>> GetPersonsAsync(PersonsFilterDto personsFilterDto);

        Task AddPersonAsync(PersonDto personDto);

        Task DeletePersonAsync(PersonDto personDto);
    }
}
