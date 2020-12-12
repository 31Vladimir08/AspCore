namespace BusinessLogic.Interfaces.Services.Notebook
{
    using System.Collections.Generic;
    using BusinessLogic.Interfaces.Services;
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;

    public interface INotebookService : IService
    {
        IEnumerable<PersonDto> GetPersons(PersonsFilterDto personsFilterDto);

        PersonDto AddPerson(PersonDto personDto);

        PersonDto DeletePerson(PersonDto personDto);

        PersonDto UpdatePerson(PersonDto personDto);

        IEnumerable<PhoneDto> GetPhones(long personId);

        IEnumerable<EmailDto> GetEmails(long personId);

        IEnumerable<SkypeDto> GetSkype(long personId);
    }
}
