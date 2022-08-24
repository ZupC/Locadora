using Api.Domain.Models;

namespace Api.Core.Interface.Repositories
{
    public interface ILocacaoRepository : IRepository<Locacao>
    {
        Task<IEnumerable<Locacao>> GetReportLateReturnAsync();
        Task<IEnumerable<Locacao>> GetReportRentedMovieAsync(int filmeID);
        Task<IEnumerable<Locacao>> GetReportRentedMovieWithDateAsync(int filmeID, DateTime data);
    }
}
