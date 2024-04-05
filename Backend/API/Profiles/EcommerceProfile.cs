using API.Dtos;
using API.Entities;
using AutoMapper;

namespace API.Profiles
{
    public class EcommerceProfile : Profile
    {
        public EcommerceProfile()
        {
            //Create
            CreateMap<ProductToCreateDto, Product>();
            CreateMap<BrandToCreateDto, Brand>();
            CreateMap<CategoryToCreateDto, Category>();
            //Delete
            //Get
            CreateMap<Product, ProductToGetDto>();
            //Update
            //Return
            CreateMap<Brand, BrandToReturnDto>();
            CreateMap<Category, CategoryToReturnDto>();
        }
    }
}
