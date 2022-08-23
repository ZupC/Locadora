using Api.Core.Cryptography;
using Api.Core.Interface.Models;
using Api.Core.Interface.Services;
using Api.Domain.Models;
using Api.Domain.Resource.Filme;
using Api.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService, IMapper mapper)
        {
            _mapper = mapper;
            _filmeService = filmeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var filmes = await _filmeService.ListAsync();
            //var x = _mapper.Map<IEnumerable<FilmeResource>>(filmes);
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var filme = await _filmeService.FindByIdAsync(ID: id);
            //var x = _mapper.Map<IEnumerable<FilmeResource>>(medicos).Select(a => new ISelectOption { Label = a.Nome, Value = a.Id });
            return Ok(filme);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var obj = await _filmeService.FindByIdAsync(ID: id);

            _filmeService.Delete(obj);
            await _filmeService.CommitAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> NewAsync([FromBody] FilmeResource filmeUpdateResource)
        {
            var filme = _mapper.Map<Filme>(filmeUpdateResource);

            await _filmeService.NewAsync(filme);
            await _filmeService.CommitAsync();

            //var filmeResource = _mapper.Map<LocacaoResource>(filme);

            return Ok(filme);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] FilmeResource filmeUpdateResource)
        {
            var filme = _mapper.Map<Filme>(filmeUpdateResource);

            _filmeService.Update(filme);
            await _filmeService.CommitAsync();

            //var filmeResource = _mapper.Map<LocacaoResource>(ordemServico);

            return Ok(filme);
        }
    }
}
