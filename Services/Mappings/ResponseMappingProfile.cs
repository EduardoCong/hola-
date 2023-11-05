using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                .ForMember(dest => dest.ID_Producto, opt => opt.MapFrom(src => src.IdProducto))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio));

            // Mapeo entre Orden y OrdenDTO
            CreateMap<Orden, OrderDTO>()
                .ForMember(dest => dest.ID_Orden, opt => opt.MapFrom(src => src.IdOrden));

            // Mapeo entre Cliente y ClienteDTO
            CreateMap<Cliente, ClienteDTO>()
            .ForMember(dest => dest.ID_Cliente, opt => opt.MapFrom(src => src.IdCliente));

            // Mapeo entre DetalleOrden y DetalleOrdenDTO
            CreateMap<DetalleOrden, DetalleOrdenDTO>()
                .ForMember(dest => dest.ID_Detalle, opt => opt.MapFrom(src => src.IdDetalle))
                .ForMember(dest => dest.ID_Orden, opt => opt.MapFrom(src => src.IdOrden))
                .ForMember(dest => dest.ID_Producto, opt => opt.MapFrom(src => src.IdProducto))
                .ForMember(dest => dest.PrecioTotal, opt => opt.MapFrom(src => src.PrecioTotal));


            // Mapeo entre Vendedor y VendedorDTO
            CreateMap<Vendedor, VendedorDTO>()
                .ForMember(dest => dest.ID_Vendedor, opt => opt.MapFrom(src => src.IdVendedor));
        }
    }
}

