using Api.Core.Interface.Repositories;
using Api.Core.Persistence.Entity;
using Api.Domain.Models;
using Api.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Repositories
{
    public class FilmeRepository : BaseRepository<Filme>, IFilmeRepository
    {
        public FilmeRepository(AppDbContext context) : base(context)
        {
        }

        public async override Task<Filme> FindByIdAsync(int ID)
        {
            return await _context.Set<Filme>().Where(a => a.Id == ID).FirstOrDefaultAsync();
        }

        public async override Task<IEnumerable<Filme>> ListAsync()
        {
            return await _context.Set<Filme>().ToListAsync();
        }
    }
}
