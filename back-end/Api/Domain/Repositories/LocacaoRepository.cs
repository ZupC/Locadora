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
    public class LocacaoRepository : BaseRepository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Locacao>> ListAsync()
        {
            return await _context.Set<Locacao>().ToListAsync();
        }

        public override async Task<Locacao> FindByIdAsync(int ID)
        {
            return await _context.Set<Locacao>().Where(a => a.Id == ID).FirstOrDefaultAsync();
        }

        public override void Update(Locacao obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public async virtual Task<IEnumerable<Locacao>> GetReportLateReturnAsync()
        {
            return await _context.Set<Locacao>().Where(a => a.DataDevolucao <= DateTime.Now.Date).ToListAsync(); ;
        }
        
        public async virtual Task<IEnumerable<Locacao>> GetReportMoviesNeverRentedAsync(int filmeID)
        {
            return await _context.Set<Locacao>().Where(a => a.FilmeId == filmeID).ToListAsync(); ;
        }
    }
}
