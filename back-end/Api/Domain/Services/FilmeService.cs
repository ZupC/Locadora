using Api.Core.Interface.Repositories;
using Api.Core.Interface.Services;
using Api.Domain.Models;
using Api.Domain.Services.Abstract;

namespace Api.Domain.Services
{
    public class FilmeService : BaseService<Filme>, IFilmeService
    {
        protected new readonly IFilmeRepository _repository;

        public FilmeService(IFilmeRepository pacienteRepository) : base(pacienteRepository)
        {
        }
    }
}
