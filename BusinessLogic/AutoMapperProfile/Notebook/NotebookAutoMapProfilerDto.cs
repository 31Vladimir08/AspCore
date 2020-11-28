namespace BusinessLogic.AutoMapperProfile.Notebook
{
    using AutoMapper;
    using BusinessLogic.Models.Notebook;
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
        }
    }
}
