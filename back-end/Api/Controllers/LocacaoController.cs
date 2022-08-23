using Api.Core.Cryptography;
using Api.Core.Interface.Services;
using Api.Domain.Models;
using Api.Domain.Resource.OrdemServico;
using Api.Domain.Services;
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
    public class LocacaoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILocacaoService _locacaoService;
        private readonly IFilmeService _filmeService;

        public LocacaoController(ILocacaoService locacaoService, IFilmeService filmeService, IMapper mapper)
        {
            _mapper = mapper;
            _locacaoService = locacaoService;
            _filmeService = filmeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var locacao = await _locacaoService.ListAsync();

            //ordens = ordens.OrderByDescending(a => a.DataLocacao);
            //var x = _mapper.Map<IEnumerable<LocacaoResource>>(locacao)

            return Ok(locacao);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIDAsync([FromRoute] int id)
        {
            var locacao = await _locacaoService.FindByIdAsync(ID: id);
            //var x = _mapper.Map<LocacaoResource>(exame);
            return Ok(locacao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var obj = await _locacaoService.FindByIdAsync(ID: id);

            _locacaoService.Delete(obj);
            await _locacaoService.CommitAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> NewAsync([FromBody] LocacaoNewUpdateResource locacaoNewUpdateResource)
        {
            var locacao = _mapper.Map<Locacao>(locacaoNewUpdateResource);
            var filme = await _filmeService.FindByIdAsync(ID: locacao.FilmeId);

            locacao.DataLocacao = DateTime.Now;

            locacao.DataDevolucao = DateTime.Now.AddDays(2);
            if (filme.Lancamento == 1)
            {
                locacao.DataDevolucao = DateTime.Now.AddDays(3);
            }

            //locacao.Protocolo = _locacaoService.GeraProtocolo(locacao);

            await _locacaoService.NewAsync(locacao);
            await _locacaoService.CommitAsync();

            //var locacaoResource = _mapper.Map<LocacaoResource>(locacao);

            return Ok(locacao);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] LocacaoNewUpdateResource locacaoNewUpdateResource)
        {
            var locacao = _mapper.Map<Locacao>(locacaoNewUpdateResource);
            var filme = await _filmeService.FindByIdAsync(ID: locacao.FilmeId);

            locacao.DataLocacao = DateTime.Now;

            locacao.DataDevolucao = DateTime.Now.AddDays(3);
            if (filme.Lancamento == 1)
            {
                locacao.DataDevolucao = DateTime.Now.AddDays(2);
            }

            _locacaoService.Update(locacao);
            await _locacaoService.CommitAsync();

            return Ok(locacao);
        }
    }
}
