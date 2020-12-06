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

        public List<PersonDto> GetPersons(PersonsFilterDto personsFilterDto)
        {
            IQueryable<PersonEntity> query = _iAplicationDbContext.Persons.AsNoTracking();
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
                query = query.Join(
                    _iAplicationDbContext.Emails.AsNoTracking().Where(x => x.EmailAddress == personsFilterDto.Email).Take(ConstConteyner.MAXCOUNTELEMENTS),
                    p => p.Id,
                    u => u.PersonId,
                    (p, u) => p);
            }

            if (!string.IsNullOrWhiteSpace(personsFilterDto.PhoneNumbers))
            {
                query = query.Join(
                    _iAplicationDbContext.Phones.AsNoTracking().Where(x => x.PhoneNumber == personsFilterDto.PhoneNumbers).Take(ConstConteyner.MAXCOUNTELEMENTS),
                    p => p.Id,
                    u => u.PersonId,
                    (p, u) => p);
            }

            if (!string.IsNullOrWhiteSpace(personsFilterDto.SkypeLogin))
            {
                query = query.Join(
                    _iAplicationDbContext.Skype.AsNoTracking().Where(x => x.SkypeLogin == personsFilterDto.SkypeLogin).Take(ConstConteyner.MAXCOUNTELEMENTS),
                    p => p.Id,
                    u => u.PersonId,
                    (p, u) => p);
            }

            query.Take(ConstConteyner.MAXCOUNTELEMENTS);
            return _iMapper.Map<List<PersonDto>>(query.ToList());
        }
    }
}
