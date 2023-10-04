using AutoMapper;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
namespace TostiElotes.Services.Mappings
{
    public class RequestCreateMappingProfile : Profile
    {
        public RequestCreateMappingProfile()
        {
            CreateMap<OrderCreateDTO, Order>();
            CreateMap<OrderCreateDTO, Order>()
            .AfterMap
						(
                (src, dest) => 
                {
                    dest.Id = src.Id;
                }
            );
            CreateMap<ProductoCreateDTO, Producto>();
             CreateMap<ProductoCreateDTO, Producto>()
            .AfterMap
						(
                (src, dest) => 
                {
                    dest.Price = src.Price;
                }
            );
            CreateMap<UsuarioCreateDTO, Usuario>();
             CreateMap<UsuarioCreateDTO, Usuario>()
            .AfterMap
			(
                (src, dest) => 
                {
                    src.id= dest.id;
                }
            );
        }
    }
}

