using Api.Core.Interface.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Core.Interface.Repositories
{
    public interface IRepository<T> where T : IModeloBase
    {
        Task<IEnumerable<T>> ListAsync();
        Task<T> FindByIdAsync(int ID);
        Task NewAsync(T obj);
        void Update(T obj);
        void Delete(T obj);
        Task CommitAsync();
    }
}
