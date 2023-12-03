using AutoMapper;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services;
using TostiElotes.Services.Features;
namespace TostiElotes.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo entre ProductoCreateDTO y Producto
            CreateMap<ProductoCreateDTO, Producto>()
            .ForMember(dest => dest.ImagenProducto, opt => opt.MapFrom(src => LeerImagenComoBytesAsync(src.ImagenProducto))); // Ignora el mapeo de IdProducto
            CreateMap<CarritoCreateDTO, CarritoDeCompra>(); // Ignora el mapeo de IdProducto
            CreateMap<LoginClienteCreateDTO, CredencialesCliente>(); // Ignora el mapeo de IdProducto
            CreateMap<LoginVendedorCreateDTO, CredencialesVendedore>(); // Ignora el mapeo de IdProducto

            // Mapeo entre OrdenCreateDTO y Orden
            CreateMap<OrdenCreateDTO, Orden>();
            CreateMap<PuestoNegocioCreateDTO, PuestosNegocio>();
            CreateMap<RepartidorCreateDTO, Repartidor>();
            CreateMap<SeguimientoEstadoCreateDTO, SeguimientoEstado>()
            .ForMember(dest => dest.IdOrden, opt => opt.MapFrom(src => src.IdOrden))
            .ForMember(dest => dest.EstadoActual, opt => opt.MapFrom(src => src.EstadoActual))
            .ForMember(dest => dest.EstadoAnterior, opt => opt.Ignore())  // Ignorar el mapeo de EstadoAnterior, ya que no existe en SeguimientoEstadoCreateDTO
            .ForMember(dest => dest.FechaCambio, opt => opt.Ignore());    // Ignorar el mapeo de FechaCambio, ya que no existe en SeguimientoEstadoCreateDTO


            


            // Mapeo entre ClienteCreateDTO y Cliente
            CreateMap<ClienteCreateDTO, Cliente>();

            // Mapeo entre DetalleOrdenCreateDTO y DetalleOrden
            CreateMap<DetallesCarritoCreateDTO, DetalleCarrito>()
            ;

            // Mapeo entre EstadoEntregaCreateDTO y EstadoEntrega
            CreateMap<NotificacionCreateDTO, Notificacione>();

            // Mapeo entre VendedorCreateDTO y Vendedor
            CreateMap<VendedorCreateDTO, Vendedor>();
        }
        public async Task<byte[]> LeerImagenComoBytesAsync(string imagen)
        {
            try
            {
                Uri? uriResult;
                bool isUrl = Uri.TryCreate(imagen, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (isUrl)
                {
                    // Descargar la imagen desde la URL
                    using (HttpClient client = new HttpClient())
                    {
                        byte[] imagenEnBytes = await client.GetByteArrayAsync(imagen);
                        return imagenEnBytes;
                    }
                }
                else
                {
                    // Es una ruta local, leer la imagen desde el archivo
                    using (FileStream fileStream = new FileStream(imagen, FileMode.Open, FileAccess.Read))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            await fileStream.CopyToAsync(memoryStream);
                            return memoryStream.ToArray();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, registrarla o lanzarla nuevamente)
                throw new Exception($"Error al leer la imagen: {ex.Message}", ex);
            }
        }

    }

}