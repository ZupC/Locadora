using Api.Core.Interface.Repositories;
using Api.Core.Interface.Services;
using Api.Domain.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Services.Abstract
{
    public class BaseService<T> : IService<T> where T : ModeloBase
    {
        protected readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async virtual Task CommitAsync()
        {
            await _repository.CommitAsync();
        }

        public virtual void Delete(T obj)
        {
            _repository.Delete(obj);
        }

        public async virtual Task<T> FindByIdAsync(int ID)
        {
            return await _repository.FindByIdAsync(ID);
        }

        public async virtual Task<IEnumerable<T>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async virtual Task NewAsync(T obj)
        {
            await _repository.NewAsync(obj);
        }

        public virtual void Update(T obj)
        {
            _repository.Update(obj);
        }
    }
}
