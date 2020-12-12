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

        public async Task<PersonDto> AddPersonAsync(PersonDto personDto)
        {
            return await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWork.CreateTransaction())
                {
                    try
                    {
                        var person = _iNotebookService.AddPerson(personDto);
                        unitOfWork.Commit();
                        return person;
                    }
                    catch (Exception e)
                    {
                        unitOfWork.Rollback();
                        throw e;
                    }
                }
            });
        }

        public async Task<PersonDto> DeletePersonAsync(PersonDto personDto)
        {
            return await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWork.CreateTransaction())
                {
                    try
                    {
                        var person = _iNotebookService.DeletePerson(personDto);
                        unitOfWork.Commit();
                        return person;
                    }
                    catch (Exception e)
                    {
                        unitOfWork.Rollback();
                        throw e;
                    }
                }
            });
        }

        public async Task<IEnumerable<PersonDto>> GetPersonsAsync(PersonsFilterDto personsFilterDto)
        {
            return await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWork.CreateTransaction())
                {
                    return _iNotebookService.GetPersons(personsFilterDto);
                }
            });
        }

        public async Task<PersonDto> UpdatePersonAsync(PersonDto personDto)
        {
            return await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWork.CreateTransaction())
                {
                    try
                    {
                        var person = _iNotebookService.UpdatePerson(personDto);
                        unitOfWork.Commit();
                        return person;
                    }
                    catch (Exception e)
                    {
                        unitOfWork.Rollback();
                        throw e;
                    }
                }
            });
        }
    }
}
