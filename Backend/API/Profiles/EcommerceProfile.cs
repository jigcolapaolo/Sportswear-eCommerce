using API.Dtos;
using API.Entities;
using AutoMapper;

namespace API.Profiles
{
    public class EcommerceProfile : Profile
    {
        public EcommerceProfile()
        {
            CreateMap<ProductToCreateDto, Product>();
            CreateMap<BrandToCreateDto, Brand>();
            CreateMap<CategoryToCreateDto, Category>();
        }
    }
}
