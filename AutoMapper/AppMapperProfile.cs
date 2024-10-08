using AutoMapper;
using storeAPI.DTOs;
using storeAPI.Models;


namespace storeAPI.AutoMapper
{
    public class AppMapperProfile : Profile
    {
       public AppMapperProfile()
       {
            CreateMap<Category, CategoryDTO>().ReverseMap();
           
            CreateMap<Product, ProductDTO>().ReverseMap();
       } 
    }
}