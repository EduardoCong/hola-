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
            CreateMap<ProductoCreateDTO, Producto>()
                .AfterMap((src, dest) => dest.IdProducto = src.ID_Producto);

            // Mapeo entre OrdenCreateDTO y Orden
            CreateMap<OrderCreateDTO, Orden>()
                .AfterMap((src, dest) => dest.IdOrden = src.ID_Orden);
            CreateMap<OrderCreateDTO, Orden>()
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha));


            // Mapeo entre ClienteCreateDTO y Cliente
            CreateMap<ClienteCreateDTO, Cliente>()
                .AfterMap((src, dest) => dest.IdCliente = src.ID_Cliente);

            // Mapeo entre DetalleOrdenCreateDTO y DetalleOrden
            CreateMap<DetalleOrdenCreateDTO, DetalleOrden>()
                .AfterMap((src, dest) => dest.IdDetalle = src.ID_Detalle);


            // Mapeo entre VendedorCreateDTO y Vendedor
            CreateMap<VendedorCreateDTO, Vendedor>()
                .AfterMap((src, dest) => dest.IdVendedor = src.ID_Vendedor);
        }
    }
}
