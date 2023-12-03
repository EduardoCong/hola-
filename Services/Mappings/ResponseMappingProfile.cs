using AutoMapper;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;

namespace TostiElotes.Services.Mappings
{
    public class ResponseMappingProfile : Profile
    {
        public ResponseMappingProfile()
        {

            // Mapeo entre Producto y ProductoDTO
            CreateMap<Producto, ProductoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria))
                .ForMember(dest => dest.ClaveProducto, opt => opt.MapFrom(src => src.ClaveProducto))
                .ForMember(dest => dest.NombreProducto, opt => opt.MapFrom(src => src.NombreProducto))
                .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.ImagenProducto, opt => opt.MapFrom(src => src.ImagenProducto))
                .ForMember(dest => dest.Tamano, opt => opt.MapFrom(src => src.Tamano))
                .ForMember(dest => dest.Sabor, opt => opt.MapFrom(src => src.Sabor))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio))
                .ForMember(dest => dest.Disponibilidad, opt => opt.MapFrom(src => src.Disponibilidad))
                .ForMember(dest => dest.PromocionesDescuentos, opt => opt.MapFrom(src => src.PromocionesDescuentos))
                .ForMember(dest => dest.IdPuesto, opt => opt.MapFrom(src => src.IdPuesto));

            // Mapeo entre Orden y OrdenDTO
            CreateMap<Orden, OrdenDTO>()
                .ForMember(dest => dest.IdOrden, opt => opt.MapFrom(src => src.IdOrden));

            // Mapeo entre Cliente y ClienteDTO
            CreateMap<Cliente, ClienteDTO>()
            .ForMember(dest => dest.IdCliente, opt => opt.MapFrom(src => src.IdCliente));

            // Mapeo entre Vendedor y VendedorDTO
            CreateMap<Vendedor, VendedorDTO>()
                .ForMember(dest => dest.IdVendedor, opt => opt.MapFrom(src => src.IdVendedor));

            CreateMap<CarritoDeCompra, CarritoDTO>(); // Ignora el mapeo de IdProducto
            CreateMap<CredencialesCliente, LoginClienteDTO>(); // Ignora el mapeo de IdProducto
            CreateMap<CredencialesVendedore, LoginVendedorDTO>(); // Ignora el mapeo de IdProducto

            // Mapeo entre OrdenCreateDTO y Orden
            CreateMap<PuestosNegocio, PuestoNegocioDTO>();
            CreateMap<Repartidor, RepartidorDTO>();
           // Mapeo de SeguimientoEstado a SeguimientoEstadoDTO
        CreateMap<SeguimientoEstado, SeguimientoEstadoDTO>()
            .ForMember(dest => dest.IdSeguimiento, opt => opt.MapFrom(src => src.IdSeguimiento))
            .ForMember(dest => dest.IdOrden, opt => opt.MapFrom(src => src.IdOrden))
            .ForMember(dest => dest.EstadoAnterior, opt => opt.MapFrom(src => src.EstadoAnterior))
            .ForMember(dest => dest.EstadoActual, opt => opt.MapFrom(src => src.EstadoActual))
            .ForMember(dest => dest.FechaCambio, opt => opt.MapFrom(src => src.FechaCambio));

            CreateMap<VendedoresProducto, VendedorProductoDTO>()
            .ForMember(dest => dest.IdVendedor, opt => opt.MapFrom(src => src.IdPuesto));
            CreateMap<VendedoresPuesto, VendedorPuestoDTO>();

            // Mapeo entre DetalleOrdenCreateDTO y DetalleOrden
            CreateMap<DetalleCarrito, DetallesCarritoDTO>()
            ;

            // Mapeo entre EstadoEntregaCreateDTO y EstadoEntrega
            CreateMap<Notificacione, NotificacionDTO>();

            // Mapeo entre VendedorCreateDTO y Vendedor
            CreateMap<Vendedor, VendedorDTO>()
                        .ForMember(dest => dest.IdVendedor, opt => opt.MapFrom(src => src.IdVendedor));

        }
    }
}