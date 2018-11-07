using AutoMapper;
using RCommerce.Module.Core.Dtos;
using RCommerce.Module.Products.Models;

namespace RCommerce.Module.Products.Modules
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(desc => desc.ParentId_Id, opt => opt.MapFrom(src => $"{src.ParentId}_{src.Id}"));
        }
    }
}
