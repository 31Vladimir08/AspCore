namespace BusinessLogic.AutoMapperProfile.Notebook
{
    using AutoMapper;
    using BusinessLogic.Models.Notebook.Entities;
    using DataAccessLayer.Models.Notebook;

    public class NotebookAutoMapProfilerDto : Profile
    {
        public NotebookAutoMapProfilerDto()
        {
            CreateProfile();
        }

        private void CreateProfile()
        {
            CreateMap<PersonEntity, PersonDto>();
            CreateMap<PersonDto, PersonEntity>();

            CreateMap<EmailEntity, EmailDto>();
            CreateMap<EmailDto, EmailEntity>();

            CreateMap<PhoneEntity, PhoneDto>();
            CreateMap<PhoneDto, PhoneEntity>();

            CreateMap<SkypeEntity, SkypeDto>();
            CreateMap<SkypeDto, SkypeEntity>();
        }
    }
}
