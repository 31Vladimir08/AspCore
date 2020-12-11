namespace BusinessLogic.Services.Notebook
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using BusinessLogic.Interfaces.Services.Notebook;
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;
    using DataAccessLayer.Interfaces;
    using DataAccessLayer.Models.Notebook;
    using Microsoft.EntityFrameworkCore;
    using Resources;

    public class NotebookService : INotebookService
    {
        private readonly IAplicationDbContext _iAplicationDbContext;
        private readonly IMapper _iMapper;

        public NotebookService(
            IAplicationDbContext iAplicationDbContext,
            IMapper iMapper)
        {
            _iAplicationDbContext = iAplicationDbContext;
            _iMapper = iMapper;
        }

        public void AddPerson(PersonDto personDto)
        {
            _iAplicationDbContext.Persons.Add(_iMapper.Map<PersonEntity>(personDto));
        }

        public void DeletePerson(PersonDto personDto)
        {
            _iAplicationDbContext.Persons.Remove(_iMapper.Map<PersonEntity>(personDto));
        }

        public List<PersonDto> GetPersons(PersonsFilterDto personsFilterDto)
        {
            IQueryable<PersonEntity> query = _iAplicationDbContext.Persons.AsNoTracking();

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
                var queryEmail = _iAplicationDbContext.Emails.AsNoTracking().Where(x => x.EmailAddress == personsFilterDto.Email)
                    .GroupBy(x => x.PersonId).Select(x => x.Key).Take(ConstConteyner.MAXCOUNTELEMENTS);
                query = query.Join(
                    queryEmail,
                    p => p.Id,
                    u => u,
                    (p, u) => p);
            }

            if (!string.IsNullOrWhiteSpace(personsFilterDto.PhoneNumbers))
            {
                var queryPhone = _iAplicationDbContext.Phones.AsNoTracking().Where(x => x.PhoneNumber == personsFilterDto.PhoneNumbers)
                    .GroupBy(x => x.PersonId).Select(x => x.Key).Take(ConstConteyner.MAXCOUNTELEMENTS);
                query = query.Join(
                    queryPhone,
                    p => p.Id,
                    u => u,
                    (p, u) => p);
            }

            if (!string.IsNullOrWhiteSpace(personsFilterDto.SkypeLogin))
            {
                var querySkype = _iAplicationDbContext.Skype.AsNoTracking().Where(x => x.SkypeLogin == personsFilterDto.SkypeLogin)
                    .GroupBy(x => x.PersonId).Select(x => x.Key).Take(ConstConteyner.MAXCOUNTELEMENTS);
                query = query.Join(
                    querySkype,
                    p => p.Id,
                    u => u,
                    (p, u) => p);
            }

            query.Take(ConstConteyner.MAXCOUNTELEMENTS);
            return _iMapper.Map<List<PersonDto>>(query.ToList());
        }
    }
}
