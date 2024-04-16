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
            CreateMap<ProductToCreateDto, Product>()
                //Cambio de List<string> a List<PictureUrl>
                .ForMember(dest => dest.PictureUrls, opt => opt.MapFrom(src => src.PictureUrls.Select(url => new PictureUrl { Url = url })));
            CreateMap<BrandToCreateDto, Brand>();
            CreateMap<CategoryToCreateDto, Category>();
            //Get
            CreateMap<Product, ProductToReturnDto>();
            //Update
            CreateMap<ProductToUpdateDto, Product>()
                //No tengo en cuenta los campos nulos
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            //Return
            CreateMap<Brand, BrandToReturnDto>();
            CreateMap<Category, CategoryToReturnDto>();
            CreateMap<BasketItemToCreateDto, BasketItem>();
        }
    }
}
