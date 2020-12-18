namespace BusinessLogic.Services.Notebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BusinessLogic.Interfaces.Services.Notebook;
    using BusinessLogic.Interfaces.UnitOfWork;
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;
    using DataAccessLayer.Models.Notebook;
    using Microsoft.EntityFrameworkCore;
    using Resources;

    public class NotebookService : INotebookService
    {
        private readonly IUnitOfWorkFactory _iUnitOfWorkFactory;
        private readonly IMapper _iMapper;

        public NotebookService(
            IUnitOfWorkFactory iUnitOfWorkFactory,
            IMapper iMapper)
        {
            _iUnitOfWorkFactory = iUnitOfWorkFactory;
            _iMapper = iMapper;
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
                    var person = _iMapper.Map<PersonDto>(
                            unitOfWork.Context.Set<PersonEntity>().Add(_iMapper.Map<PersonEntity>(personDto)).Entity);
                    unitOfWork.Commit();
                    return person;
                }
            });
        }

        public async Task<PersonDto> DeletePersonAsync(PersonDto personDto)
        {
            return await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWorkFactory.Create())
                {
                    var person = _iMapper.Map<PersonDto>(
                            unitOfWork.Context.Set<PersonEntity>().Remove(_iMapper.Map<PersonEntity>(personDto)).Entity);
                    unitOfWork.Commit();
                    return person;
                }
            });
        }

        public async Task<(
            Task<PersonDto> person,
            Task<IEnumerable<EmailDto>> emails,
            Task<IEnumerable<PhoneDto>> phones,
            Task<IEnumerable<SkypeDto>> skype)> GetDetalsAsync(long personId)
        {
            var person = Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWorkFactory.Create())
                {
                    return _iMapper.Map<PersonDto>(
                            unitOfWork.Context.Set<PersonEntity>().Find(personId));
                }
            });

            var emails = Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWorkFactory.Create())
                {
                    return _iMapper.Map<IEnumerable<EmailDto>>(
                            unitOfWork.Context.Set<EmailEntity>().Where(x => x.PersonId == personId).Take(ConstConteyner.MAXCOUNTELEMENTS));
                }
            });

            var phones = Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWorkFactory.Create())
                {
                    return _iMapper.Map<IEnumerable<PhoneDto>>(
                            unitOfWork.Context.Set<PhoneEntity>().Where(x => x.PersonId == personId).Take(ConstConteyner.MAXCOUNTELEMENTS));
                }
            });

            var skype = Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWorkFactory.Create())
                {
                    return _iMapper.Map<IEnumerable<SkypeDto>>(
                            unitOfWork.Context.Set<SkypeEntity>().Where(x => x.PersonId == personId).Take(ConstConteyner.MAXCOUNTELEMENTS));
                }
            });

            await Task.WhenAll(person, emails, phones, skype);
            var result =
                (
                    person: person,
                    emails: emails,
                    phones: phones,
                    skype: skype
                );

            return result;
        }

        public async Task<IEnumerable<PersonDto>> GetPersonsAsync(PersonsFilterDto personsFilterDto)
        {
            return await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWorkFactory.Create())
                {
                    IQueryable<PersonEntity> query = unitOfWork.Context.Set<PersonEntity>().AsNoTracking();

                    if (personsFilterDto.Id != null && personsFilterDto.Id > 0)
                    {
                        query = query.Where(x => x.Id == personsFilterDto.Id);
                    }

                    if (!string.IsNullOrWhiteSpace(personsFilterDto.Surname))
                    {
                        query = query.Where(x => x.Surname == personsFilterDto.Surname);
                    }

                    if (!string.IsNullOrWhiteSpace(personsFilterDto.Name))
                    {
                        query = query.Where(x => x.Name == personsFilterDto.Name);
                    }

                    if (!string.IsNullOrWhiteSpace(personsFilterDto.Patronymic))
                    {
                        query = query.Where(x => x.Patronymic == personsFilterDto.Patronymic);
                    }

                    if (!string.IsNullOrWhiteSpace(personsFilterDto.Organization))
                    {
                        query = query.Where(x => x.Organization == personsFilterDto.Organization);
                    }

                    if (personsFilterDto.DateOfBirth?.FromDateTime != null)
                    {
                        query = query.Where(x => x.DateOfBirth >= personsFilterDto.DateOfBirth.FromDateTime);
                    }

                    if (personsFilterDto.DateOfBirth?.ToDateTime != null)
                    {
                        query = query.Where(x => x.DateOfBirth <= personsFilterDto.DateOfBirth.ToDateTime);
                    }

                    if (!string.IsNullOrWhiteSpace(personsFilterDto.Email))
                    {
                        var queryEmail = unitOfWork.Context.Set<EmailEntity>().AsNoTracking().Where(x => x.EmailAddress == personsFilterDto.Email)
                            .GroupBy(x => x.PersonId).Select(x => x.Key).Take(ConstConteyner.MAXCOUNTELEMENTS);
                        query = query.Join(
                            queryEmail,
                            p => p.Id,
                            u => u,
                            (p, u) => p);
                    }

                    if (!string.IsNullOrWhiteSpace(personsFilterDto.PhoneNumbers))
                    {
                        var queryPhone = unitOfWork.Context.Set<PhoneEntity>().AsNoTracking().Where(x => x.PhoneNumber == personsFilterDto.PhoneNumbers)
                            .GroupBy(x => x.PersonId).Select(x => x.Key).Take(ConstConteyner.MAXCOUNTELEMENTS);
                        query = query.Join(
                            queryPhone,
                            p => p.Id,
                            u => u,
                            (p, u) => p);
                    }

                    if (!string.IsNullOrWhiteSpace(personsFilterDto.SkypeLogin))
                    {
                        var querySkype = unitOfWork.Context.Set<SkypeEntity>().AsNoTracking().Where(x => x.SkypeLogin == personsFilterDto.SkypeLogin)
                            .GroupBy(x => x.PersonId).Select(x => x.Key).Take(ConstConteyner.MAXCOUNTELEMENTS);
                        query = query.Join(
                            querySkype,
                            p => p.Id,
                            u => u,
                            (p, u) => p);
                    }

                    query.Take(ConstConteyner.MAXCOUNTELEMENTS);

                    var persons = _iMapper.Map<IEnumerable<PersonDto>>(query);
                    return persons;
                }
            });
        }

        public async Task<PersonDto> UpdatePersonAsync(PersonDto personDto)
        {
            return await Task.Run(() =>
            {
                using (var unitOfWork = _iUnitOfWorkFactory.Create())
                {
                    var person = _iMapper.Map<PersonDto>(
                            unitOfWork.Context.Set<PersonEntity>().Update(_iMapper.Map<PersonEntity>(personDto)).Entity);
                    unitOfWork.Commit();
                    return person;
                }
            });
        }
    }
}
