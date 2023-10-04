using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;
using TostiElotes.Domain.Dtos;


namespace TostiElotes.Controllers.V1;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderServices _orderervices;
    private readonly IMapper _mapper;
    public OrderController(OrderServices Orderervices, IMapper mapper)
    {
        this._orderervices = Orderervices ?? throw new ArgumentNullException(nameof(Orderervices));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task <IActionResult> GetAll()
    {
        var order = await _orderervices.GetAll();
        var mangaDtos = _mapper.Map<IEnumerable<OrderDTO>>(order);

        return Ok(mangaDtos);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _orderervices.GetById(id);

        if (order.Id <= 0)
            return NotFound();

        var dto = _mapper.Map<OrderDTO>(order);

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Add(OrderCreateDTO order)
    {
        var entity = _mapper.Map<Order>(order);
        await _orderervices.Add(entity);
        var dto = _mapper.Map<OrderDTO>(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);

    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Order order)
    {
        if (id != order.Id)
        return BadRequest();

        var existingOrder = await _orderervices.GetById(id);

        if(existingOrder == null)
        return NotFound();

        _mapper.Map(order, existingOrder);

        await _orderervices.Update(existingOrder);

        var updatedOrder = await _orderervices.GetById(id);
        var updatedOrderDto = _mapper.Map<OrderDTO>(updatedOrder);
        
        return Ok(updatedOrderDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _orderervices.Delete(id);
        return NoContent();
    }
}