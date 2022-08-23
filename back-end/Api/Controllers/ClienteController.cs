using Api.Core.Cryptography;
using Api.Core.Interface.Models;
using Api.Core.Interface.Services;
using Api.Domain.Models;
using Api.Domain.Resource.Cliente;
using Api.Domain.Resource.OrdemServico;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _mapper = mapper;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var clientes = await _clienteService.ListAsync();
            //var x = _mapper.Map<IEnumerable<ClienteResource>>(clientes);
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var cliente = await _clienteService.FindByIdAsync(ID: id);
            //var x = _mapper.Map<IEnumerable<ClienteResource>>(medicos).Select(a => new ISelectOption { Label = a.Nome, Value = a.Id });
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var obj = await _clienteService.FindByIdAsync(ID: id);

            _clienteService.Delete(obj);
            await _clienteService.CommitAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> NewAsync([FromBody] ClienteResource clienteUpdateResource)
        {
            var cliente = _mapper.Map<Cliente>(clienteUpdateResource);

            await _clienteService.NewAsync(cliente);
            await _clienteService.CommitAsync();

            return Ok(cliente);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ClienteResource clienteUpdateResource)
        {
            var cliente = _mapper.Map<Cliente>(clienteUpdateResource);

            _clienteService.Update(cliente);
            await _clienteService.CommitAsync();

            return Ok(cliente);
        }
    }
}
