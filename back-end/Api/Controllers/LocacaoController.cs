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
        private readonly IClienteService _clienteService;

        public LocacaoController(ILocacaoService locacaoService, IFilmeService filmeService, IClienteService clienteService, IMapper mapper)
        {
            _mapper = mapper;
            _locacaoService = locacaoService;
            _filmeService = filmeService;
            _clienteService = clienteService;
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

        [HttpGet]
        [Route("ReportLateReturn")]
        public async Task<IActionResult> GetReportLateReturnAsync()
        {
            var locacoesAtrasadas = await _locacaoService.GetReportLateReturnAsync();
            List<Cliente> clientes = new List<Cliente>();

            if (locacoesAtrasadas.Count() == 0)
            {
                return Ok("Não a devoluções atrasadas");
            }
            else
            {
                foreach (var locacaoAtrasada in locacoesAtrasadas)
                {
                    var cliente = _clienteService.FindByIdAsync(locacaoAtrasada.ClienteId).Result;

                    if (!clientes.Contains(cliente))
                    {
                        clientes.Add(cliente);
                    }
                }

                return Ok(clientes);
            }

        }

        [HttpGet]
        [Route("ReportMoviesNeverRented")]
        public async Task<IActionResult> GetReportMoviesNeverRentedAsync()
        {
            var filmes = await _filmeService.ListAsync();
            List<Filme> filmesNaoAlugados = new List<Filme>();
            foreach (var filme in filmes)
            {
                var quantidadeFilmesAlugados = _locacaoService.GetReportRentedMovieAsync(filme.Id).Result;

                if (quantidadeFilmesAlugados.Count() == 0)
                {
                    filmesNaoAlugados.Add(filme);
                }
            }
            return Ok(filmesNaoAlugados);
        }

        [HttpGet]
        [Route("ReportMostRentedMovies")]
        public async Task<IActionResult> GetReportMostRentedMoviesAsync()
        {
            var filmes = await _filmeService.ListAsync();
            var list = Enumerable.Empty<object>().Select(r => new { Titulo = "", VezesAlugado = 0 }).ToList();

            foreach (var filme in filmes)
            {
                var quantidadeVezesFilmeAlugado = _locacaoService.GetReportRentedMovieWithDateAsync(filme.Id, DateTime.Now.AddYears(-1)).Result.Count();

                list.Add(new { Titulo = filme.Titulo, VezesAlugado = quantidadeVezesFilmeAlugado });
            }

            list.Sort((l1, l2) => {
                return l2.VezesAlugado.CompareTo(l1.VezesAlugado);
            });

            return Ok(list.Take(5));
        }

        [HttpGet]
        [Route("ReportLessRentedMovies")]
        public async Task<IActionResult> GetReportLessRentedMoviesAsync()
        {
            var filmes = await _filmeService.ListAsync();
            var list = Enumerable.Empty<object>().Select(r => new { Titulo = "", VezesAlugado = 0 }).ToList();

            foreach (var filme in filmes)
            {
                var quantidadeVezesFilmeAlugado = _locacaoService.GetReportRentedMovieWithDateAsync(filme.Id, DateTime.Now.AddDays(-7)).Result.Count();

                list.Add(new { Titulo = filme.Titulo, VezesAlugado = quantidadeVezesFilmeAlugado });
            }

            list.Sort((l1, l2) => {
                return l1.VezesAlugado.CompareTo(l2.VezesAlugado);
            });

            return Ok(list.Take(3));
        }

        [HttpGet]
        [Route("ReportSecondMostCustomerRented")]
        public async Task<IActionResult> GetReportSecondMostCustomerRentedAsync()
        {
            var clientes = await _clienteService.ListAsync();
            var list = Enumerable.Empty<object>().Select(r => new { Nome = "", VezesAlugado = 0 }).ToList();

            foreach (var cliente in clientes)
            {
                var quantidadeVezesClienteAlugou = _locacaoService.GetReportCustomerRentedAsync(cliente.Id).Result.Count();

                list.Add(new { Nome = cliente.Nome, VezesAlugado = quantidadeVezesClienteAlugou });
            }

            list.Sort((l1, l2) => {
                return l2.VezesAlugado.CompareTo(l1.VezesAlugado);
            });

            return Ok(list[1]);
        }
    }
}
