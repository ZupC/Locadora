using Api.Domain.Models;

namespace Api.Core.Interface.Services
{
    public interface ILocacaoService : IService<Locacao>
    {
        Task<IEnumerable<Locacao>> GetReportLateReturnAsync();
        Task<IEnumerable<Locacao>> GetReportRentedMovieAsync(int filmeID);
        Task<IEnumerable<Locacao>> GetReportRentedMovieWithDateAsync(int filmeID, DateTime data);
    }
}
