namespace BusinessLogic.Interfaces.Notebook
{
    using BusinessLogic.Models.Notebook;
    using System.Collections.Generic;

    public interface INotebookService : IService
    {
        List<PersonDto> GetPersons();
    }
}
