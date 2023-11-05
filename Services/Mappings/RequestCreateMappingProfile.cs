using AutoMapper;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;

namespace TostiElotes.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo entre ProductoCreateDTO y Producto
            CreateMap<ProductoCreateDTO, Producto>(); // Ignora el mapeo de IdProducto

            // Mapeo entre OrdenCreateDTO y Orden
            CreateMap<OrderCreateDTO, Orden>()
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha));


            // Mapeo entre ClienteCreateDTO y Cliente
            CreateMap<ClienteCreateDTO, Cliente>();

            // Mapeo entre DetalleOrdenCreateDTO y DetalleOrden
            CreateMap<DetalleOrdenCreateDTO, DetalleOrden>()
            ;


            // Mapeo entre VendedorCreateDTO y Vendedor
            CreateMap<VendedorCreateDTO, Vendedor>();
        }
    }
}
