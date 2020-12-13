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

        public EmailDto AddEmail(EmailDto emailDto)
        {
            var email = _iMapper.Map<EmailDto>(_iAplicationDbContext.Emails.Add(_iMapper.Map<EmailEntity>(emailDto)).Entity);
            return email;
        }

        public PersonDto AddPerson(PersonDto personDto)
        {
            var person = _iMapper.Map<PersonDto>(_iAplicationDbContext.Persons.Add(_iMapper.Map<PersonEntity>(personDto)).Entity);
            return person;
        }

        public PhoneDto AddPhone(PhoneDto phoneDto)
        {
            var phone = _iMapper.Map<PhoneDto>(_iAplicationDbContext.Phones.Add(_iMapper.Map<PhoneEntity>(phoneDto)).Entity);
            return phone;
        }

        public SkypeDto AddSkype(SkypeDto skypeDto)
        {
            var skype = _iMapper.Map<SkypeDto>(_iAplicationDbContext.Skype.Add(_iMapper.Map<SkypeEntity>(skypeDto)).Entity);
            return skype;
        }

        public PersonDto DeletePerson(PersonDto personDto)
        {
            var person =_iMapper.Map<PersonDto>(_iAplicationDbContext.Persons.Remove(_iMapper.Map<PersonEntity>(personDto)).Entity);
            return person;
        }

        public IEnumerable<EmailDto> GetEmails(long personId)
        {
            var emails = _iMapper.Map<IEnumerable<EmailDto>>(_iAplicationDbContext.Emails.Where(x => x.PersonId == personId));
            return emails;
        }

        public IEnumerable<PersonDto> GetPersons(PersonsFilterDto personsFilterDto)
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

            var persons = _iMapper.Map<IEnumerable<PersonDto>>(query);
            return persons;
        }

        public IEnumerable<PhoneDto> GetPhones(long personId)
        {
            var phones = _iMapper.Map<IEnumerable<PhoneDto>>(_iAplicationDbContext.Phones.Where(x => x.PersonId == personId));
            return phones;
        }

        public IEnumerable<SkypeDto> GetSkype(long personId)
        {
            var skype = _iMapper.Map<IEnumerable<SkypeDto>>(_iAplicationDbContext.Skype.Where(x => x.PersonId == personId));
            return skype;
        }

        public PersonDto UpdatePerson(PersonDto personDto)
        {
            var person = _iMapper.Map<PersonDto>(_iAplicationDbContext.Persons.Update(_iMapper.Map<PersonEntity>(personDto)).Entity);
            return person;
        }
    }
}
