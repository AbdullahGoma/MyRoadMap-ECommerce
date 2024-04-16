using AutoMapper;
using Bulky.Models.Entities;

namespace BulkyWeb.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Category
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryFormViewModel, Category>().ReverseMap();
        }
    }
}
