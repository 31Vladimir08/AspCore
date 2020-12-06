namespace BusinessLogic.Logic.Notebook
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLogic.Interfaces;
    using BusinessLogic.Interfaces.Logic.Notebook;
    using BusinessLogic.Interfaces.Services.Notebook;
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;

    public class NotebookLogic : INotebookLogic
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly INotebookService _iNotebookService;

        public NotebookLogic(
            IUnitOfWork iUnitOfWork,
            INotebookService iNotebookService)
        {
            _iUnitOfWork = iUnitOfWork;
            _iNotebookService = iNotebookService;
        }

        public async Task AddPersonAsync(PersonDto personDto)
        {
            await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWork.CreateTransaction())
                {
                    try
                    {
                        _iNotebookService.AddPerson(personDto);
                        unitOfWork.Commit();
                    }
                    catch (Exception e)
                    {
                        unitOfWork.Rollback();
                        throw e;
                    }
                }
            });
        }

        public async Task<List<PersonDto>> GetPersonsAsync(PersonsFilterDto personsFilterDto)
        {
            return await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWork.CreateTransaction())
                {
                    return _iNotebookService.GetPersons(personsFilterDto);
                }
            });
        }
    }
}
