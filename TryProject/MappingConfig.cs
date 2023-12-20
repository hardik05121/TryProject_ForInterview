using AutoMapper;
using TryProject.Model;
using TryProject.Model.DTO;

namespace TryProject
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
        }
    }
}
