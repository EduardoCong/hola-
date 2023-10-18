using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;
using TostiElotes.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TostiElotes.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VendedoresController : ControllerBase
    {
        private readonly VendedorServices _vendedorServices;
        private readonly IMapper _mapper;

        public VendedoresController(VendedorServices vendedorServices, IMapper mapper)
        {
            this._vendedorServices = vendedorServices ?? throw new ArgumentNullException(nameof(vendedorServices));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vendedores = await _vendedorServices.GetAll();
            var vendedorDtos = _mapper.Map<IEnumerable<VendedorDTO>>(vendedores);

            return Ok(vendedorDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vendedor = await _vendedorServices.GetById(id);

            if (vendedor == null)
                return NotFound();

            var dto = _mapper.Map<VendedorDTO>(vendedor);

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(VendedorCreateDTO vendedor)
        {
            var entity = _mapper.Map<Vendedor>(vendedor);

            await _vendedorServices.Add(entity);
            var dto = _mapper.Map<VendedorDTO>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.IdVendedor }, dto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, VendedorCreateDTO vendedor)
        {
            if (id != vendedor.ID_Vendedor)
                return BadRequest();

            var existingVendedor = await _vendedorServices.GetById(id);

            if (existingVendedor == null)
                return NotFound();

            _mapper.Map(vendedor, existingVendedor);

            await _vendedorServices.Update(existingVendedor);

            var updatedVendedor = await _vendedorServices.GetById(id);
            var updatedVendedorDto = _mapper.Map<VendedorDTO>(updatedVendedor);

            return Ok(updatedVendedorDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _vendedorServices.Delete(id);
            return NoContent();
        }
    }
}
