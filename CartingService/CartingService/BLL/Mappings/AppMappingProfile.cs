using AutoMapper;
using CartService.BLL.Entities.Insert;
using CartService.BLL.Entities.View;
using CartService.Domain.Entities;

namespace CartService.BLL.Mappings
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<ImageInfo, ImageInfoViewModel>();
            CreateMap<Item, ItemViewModel>();
            CreateMap<Cart, CartViewModel>();

            CreateMap<ImageInfoInsertViewModel, ImageInfo>();
            CreateMap<ItemInsertViewModel, Item>();
            CreateMap<CartInsertViewModel, Cart>();
        }
    }
}