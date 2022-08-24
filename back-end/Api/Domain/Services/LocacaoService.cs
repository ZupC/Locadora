using Api.Core.Interface.Repositories;
using Api.Core.Interface.Services;
using Api.Domain.Models;
using Api.Domain.Services.Abstract;

namespace Api.Domain.Services
{
    public class LocacaoService : BaseService<Locacao>, ILocacaoService
    {
        protected new readonly ILocacaoRepository _repository;

        public LocacaoService(ILocacaoRepository locacaoRepository) : base(locacaoRepository)
        {
            _repository = locacaoRepository;
        }
        public async virtual Task<IEnumerable<Locacao>> GetReportLateReturnAsync()
        {
            return await _repository.GetReportLateReturnAsync();
        }

    }
}
