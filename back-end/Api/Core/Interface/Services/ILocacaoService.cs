using Api.Domain.Models;

namespace Api.Core.Interface.Services
{
    public interface ILocacaoService : IService<Locacao>
    {
        Task<IEnumerable<Locacao>> GetReportLateReturnAsync();
    }
}
