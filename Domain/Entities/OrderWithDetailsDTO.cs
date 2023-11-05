using TostiElotes.Domain.Dtos;

namespace TostiElotes.Domain.Entities
{
    public class OrderWithDetailsDTO
{
    public OrderCreateDTO? Order { get; set; }
    public DetalleOrdenCreateDTO? DetalleOrden { get; set; }
}
}