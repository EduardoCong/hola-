using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TostiElotes.Domain.Dtos;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;

[ApiController]
[Route("api/v1/[controller]")]
public class EstadoEntregaController : ControllerBase
{
    private readonly EstadoEntregaServices _context;
    private readonly OrdenServices _ordenServices;
    private readonly IMapper _mapper;

    public EstadoEntregaController(EstadoEntregaServices context, IMapper mapper, OrdenServices ordenServices)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        this._ordenServices = ordenServices ?? throw new ArgumentNullException(nameof(ordenServices));
    }

    [HttpGet("Estados")]
    public async Task<IActionResult> GetEstadoEntregas()
    {
        var estados = await _context.GetAll();
        var estadoEntregaDTOs = _mapper.Map<IEnumerable<EstadoEsntregaDTO>>(estados);

        return Ok(estadoEntregaDTOs);
    }

    [HttpGet("Estados/{idOrden}")]
    public async Task<ActionResult> GetEstadoEntregaByOrden(int idOrden)
    {
        var estadoEntrega = await _context.GetById(idOrden);
        if (estadoEntrega.IdEstado == 0)
            return BadRequest("La orden no existe.");
        ;

        var dto = _mapper.Map<EstadoEsntregaDTO>(estadoEntrega);

        return Ok(dto);
    }

    [HttpPost("EntregarPedido")]
    public async Task<ActionResult> PostEstadoEntrega(int idOrden, string comentarios)
    {
        // Buscar el EstadoEntrega por el ID de la orden
        var estadoEntrega = await _context.GetById(idOrden);

        if (estadoEntrega.IdOrden == 0)
        {
            return BadRequest("La orden no existe.");
        }
        else
        {
            if (estadoEntrega.Estado != "Enviado")
            {
                // Actualiza el estado de entrega a "enviado"
                estadoEntrega.Estado = "Enviado";
                estadoEntrega.Comentarios = comentarios;

                // Actualiza el EstadoEntrega en la base de datos
                await _context.Update(estadoEntrega);

                return Ok("El pedido se ha entregado."); // Devuelve un mensaje de éxito
            }
            else
            {
                return BadRequest("El pedido ya se encuentra entregado."); // Devuelve un mensaje de éxito
            }
        }
    }


}
