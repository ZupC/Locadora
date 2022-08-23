using Api.Core.Interface.Repositories;
using Api.Core.Interface.Services;
using Api.Domain.Models;
using Api.Domain.Services.Abstract;

namespace Api.Domain.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        protected new readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository clienteRepository) : base(clienteRepository)
        {
        }
    }
}
