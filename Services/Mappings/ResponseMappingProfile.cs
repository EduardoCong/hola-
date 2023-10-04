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
            CreateMap<Order, OrderDTO>();

            CreateMap<Order, OrderDTO>()    
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id)
            );
            CreateMap<Producto, ProductoDTO>();

            CreateMap<Producto, ProductoDTO>()
            .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(src => src.Price)
            );
            CreateMap<Usuario, UsuarioDTO>();

            CreateMap<Usuario, UsuarioDTO>()
            .ForMember(
                dest => dest.firs_tName,
                opt => opt.MapFrom(src => src.first_Name)
            );
        }
    }
}
