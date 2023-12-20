using AutoMapper;
using TryProjectWeb.Model.DTO;


namespace TryProjectWeb
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<CategoryDTO, CategoryCreateDTO>().ReverseMap();
        }
    }
}
