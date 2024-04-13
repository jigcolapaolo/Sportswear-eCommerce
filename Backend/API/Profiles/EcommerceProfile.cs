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
            //Get
            CreateMap<Product, ProductToReturnDto>();
            //Update
            CreateMap<ProductToUpdateDto, Product>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            //Return
            CreateMap<Brand, BrandToReturnDto>();
            CreateMap<Category, CategoryToReturnDto>();
            CreateMap<BasketItemToCreateDto, BasketItem>();
        }
    }
}
