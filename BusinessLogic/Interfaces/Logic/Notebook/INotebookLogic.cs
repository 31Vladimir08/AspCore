namespace BusinessLogic.Interfaces.Logic.Notebook
{
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface INotebookLogic
    {
        Task<List<PersonDto>> GetPersonsAsync(PersonsFilterDto personsFilterDto);
    }
}
