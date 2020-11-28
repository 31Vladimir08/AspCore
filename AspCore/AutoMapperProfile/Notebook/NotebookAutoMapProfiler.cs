namespace AspCore.AutoMapperProfile.Notebook
{
    using AspCore.Models.Notebook;
    using AutoMapper;
    using BusinessLogic.Models.Notebook;

    public class NotebookAutoMapProfiler : Profile
    {
        public NotebookAutoMapProfiler()
        {
            CreateProfile();
        }

        private void CreateProfile()
        {
            CreateMap<PersonUi, PersonDto>();
            CreateMap<PersonDto, PersonUi>();
        }
    }
}
