namespace BusinessLogic.Interfaces.Logic.Notebook
{
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface INotebookLogic
    {
        List<PersonDto> GetPersons(PersonsFilterDto personsFilterDto);
    }
}
