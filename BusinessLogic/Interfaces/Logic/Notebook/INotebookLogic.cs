namespace BusinessLogic.Interfaces.Logic.Notebook
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;

    public interface INotebookLogic
    {
        Task<IEnumerable<PersonDto>> GetPersonsAsync(PersonsFilterDto personsFilterDto);

        Task<PersonDto> AddPersonAsync(PersonDto personDto);

        Task<PersonDto> DeletePersonAsync(PersonDto personDto);

        Task<PersonDto> UpdatePersonAsync(PersonDto personDto);
    }
}
