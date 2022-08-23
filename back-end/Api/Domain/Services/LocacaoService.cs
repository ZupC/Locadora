using Api.Core.Interface.Repositories;
using Api.Core.Interface.Services;
using Api.Domain.Models;
using Api.Domain.Services.Abstract;

namespace Api.Domain.Services
{
    public class LocacaoService : BaseService<Locacao>, ILocacaoService
    {
        protected new readonly ILocacaoRepository _repository;

        public LocacaoService(ILocacaoRepository ordemServicoRepository) : base(ordemServicoRepository)
        {
        }

        //public string GeraProtocolo(Locacao locacao)
        //{
        //    return $"{locacao.Data.Ticks}";
        //}
    }
}
