namespace BusinessLogic.Logic.Notebook
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
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

        public async Task<dynamic> GetDetalsAsync(long personId)
        {
            return await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWork.CreateTransaction())
                {
                    var person = _iNotebookService.GetPersons(new PersonsFilterDto() { Id = personId }).FirstOrDefault();
                    var emails = _iNotebookService.GetEmails(personId);
                    var phones = _iNotebookService.GetPhones(personId);
                    var skype = _iNotebookService.GetSkype(personId);
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
