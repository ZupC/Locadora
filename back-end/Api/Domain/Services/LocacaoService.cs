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
        public async virtual Task<IEnumerable<Locacao>> GetReportRentedMovieAsync(int filmeID)
        {
            return await _repository.GetReportRentedMovieAsync(filmeID);
        }
        public async virtual Task<IEnumerable<Locacao>> GetReportRentedMovieWithDateAsync(int filmeID, DateTime data)
        {
            return await _repository.GetReportRentedMovieWithDateAsync(filmeID, data);
        }

        public async virtual Task<IEnumerable<Locacao>> GetReportCustomerRentedAsync(int clienteID)
        {
            return await _repository.GetReportCustomerRentedAsync(clienteID);
        }
    }
}
