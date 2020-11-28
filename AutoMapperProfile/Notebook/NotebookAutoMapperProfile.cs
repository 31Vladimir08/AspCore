namespace AutoMapperProfile.Notebook
{
    using AspCore.Models.Notebook;
    using AutoMapper;
    using BusinessLogic.Models.Notebook;
    using DataAccessLayer.Models.Notebook;

    public class NotebookAutoMapperProfile : Profile
    {
        public NotebookAutoMapperProfile()
        {
            CreateDtoUiProfile();
            CreateDtoEntityProfile();
        }

        private void CreateDtoUiProfile()
        {
            CreateMap<PersonUi, PersonDto>();
            CreateMap<PersonDto, PersonUi>();
        }
        private void CreateDtoEntityProfile()
        {
            CreateMap<PersonEntity, PersonDto>();
            CreateMap<PersonDto, PersonEntity>();
        }
    }
}
