namespace AspCore.AutoMapperProfile.Notebook
{
    using AspCore.Models.Notebook;
    using AspCore.Models.Notebook.Filters;
    using AutoMapper;
    using BusinessLogic.Models.Notebook.Entities;
    using BusinessLogic.Models.Notebook.Filters;

    public class NotebookAutoMapProfiler : Profile
    {
        public NotebookAutoMapProfiler()
        {
            CreateProfile();
            CreateFiltersProfile();
        }

        private void CreateProfile()
        {
            CreateMap<PersonUi, PersonDto>();
            CreateMap<PersonDto, PersonUi>();

            CreateMap<EmailUi, EmailDto>();
            CreateMap<EmailDto, EmailUi>();

            CreateMap<PhoneUi, PhoneDto>();
            CreateMap<PhoneDto, PhoneUi>();

            CreateMap<SkypeUi, SkypeDto>();
            CreateMap<SkypeDto, SkypeUi>();
        }

        private void CreateFiltersProfile()
        {
            CreateMap<PersonsFilterUi, PersonsFilterDto>();
            CreateMap<PersonsFilterDto, PersonsFilterUi>();
        }
    }
}
