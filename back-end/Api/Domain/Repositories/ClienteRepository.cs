using Api.Core.Interface.Repositories;
using Api.Core.Persistence.Entity;
using Api.Domain.Models;
using Api.Domain.Repositories.Abstract;

namespace Api.Domain.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
