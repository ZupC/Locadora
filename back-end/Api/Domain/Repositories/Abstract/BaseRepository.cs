using Api.Core.Interface.Repositories;
using Api.Core.Persistence.Entity;
using Api.Domain.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IRepository<T> where T : ModeloBase
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async virtual Task<T> FindByIdAsync(int ID)
        {
            return await _context.Set<T>().Where(a => a.Id == ID).FirstOrDefaultAsync();
        }

        public async virtual Task<IEnumerable<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async virtual Task NewAsync(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
        }

        public async virtual Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual void Update(T obj)
        {
            _context.Set<T>().Update(obj);
        }

        public virtual void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
        }
    }
}
