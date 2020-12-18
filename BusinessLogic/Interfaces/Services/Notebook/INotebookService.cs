namespace BusinessLogic.Interfaces.Services.Notebook
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;

    public interface INotebookService : IService
    {
        Task<IEnumerable<PersonDto>> GetPersonsAsync(PersonsFilterDto personsFilterDto);

        Task<PersonDto> AddPersonAsync(PersonDto personDto);

        Task<PersonDto> DeletePersonAsync(PersonDto personDto);

        Task<PersonDto> UpdatePersonAsync(PersonDto personDto);

        Task<(
            Task<PersonDto> person,
            Task<IEnumerable<EmailDto>> emails,
            Task<IEnumerable<PhoneDto>> phones,
            Task<IEnumerable<SkypeDto>> skype)> GetDetalsAsync(long personId);

        Task<dynamic> AddDetalsForPersonAsync(long personId);
    }
}
