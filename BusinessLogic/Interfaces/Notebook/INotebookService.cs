namespace BusinessLogic.Interfaces.Notebook
{
    using System.Collections.Generic;
    using BusinessLogic.Models.Notebook;

    public interface INotebookService : IService
    {
        List<PersonDto> GetPersons();

        void AddPerson(PersonDto personDto);
    }
}
