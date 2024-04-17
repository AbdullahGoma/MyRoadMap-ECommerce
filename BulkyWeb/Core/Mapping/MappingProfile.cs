using AutoMapper;
using Bulky.Models.Entities;

namespace BulkyWeb.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // Categories
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryFormViewModel, Category>().ReverseMap();

            // Products
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductFormViewModel, Product>().ReverseMap();
        }
    }
}
