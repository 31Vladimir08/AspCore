namespace BusinessLogic.Logic.Notebook
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Threading.Tasks;
    using BusinessLogic.Interfaces.Logic.Notebook;
    using BusinessLogic.Interfaces.Services.Notebook;
    using BusinessLogic.Interfaces.UnitOfWork;
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;

    public class NotebookLogic : INotebookLogic
    {
        private readonly IUnitOfWorkFactory _iUnitOfWorkFactory;
        private readonly INotebookService _notebookService;

        public NotebookLogic(
            IUnitOfWorkFactory iUnitOfWorkFactory,
            INotebookService notebookService)
        {
            _iUnitOfWorkFactory = iUnitOfWorkFactory;
            _notebookService = notebookService;
        }

        public async Task<dynamic> AddDetalsForPersonAsync(long personId)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonDto> AddPersonAsync(PersonDto personDto)
        {
            return await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWorkFactory.Create())
                {
                    try
                    {
                        var person = _notebookService.AddPerson(personDto);
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
                using (var unitOfWork = _iUnitOfWorkFactory.Create())
                {
                    try
                    {
                        var person = _notebookService.DeletePerson(personDto);
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

        public async Task<dynamic> GetDetalsAsync(long personId)
        {
            return await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWorkFactory.Create())
                {
                    var person = _notebookService.GetPersons(new PersonsFilterDto() { Id = personId }).FirstOrDefault();
                    var emails = _notebookService.GetEmails(personId);
                    var phones = _notebookService.GetPhones(personId);
                    var skype = _notebookService.GetSkype(personId);
                    dynamic result = new ExpandoObject();
                    result.Person = person;
                    result.Emails = emails;
                    result.Phones = phones;
                    result.Skype = skype;

                    return result;
                }
            });
        }

        public async Task<IEnumerable<PersonDto>> GetPersonsAsync(PersonsFilterDto personsFilterDto)
        {
            return await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWorkFactory.Create())
                {
                    return _notebookService.GetPersons(personsFilterDto);
                }
            });
        }

        public async Task<PersonDto> UpdatePersonAsync(PersonDto personDto)
        {
            return await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWorkFactory.Create())
                {
                    try
                    {
                        var person = _notebookService.UpdatePerson(personDto);
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
