using MagniFinance.Domain.Entities;
using MagniFinance.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagniFinance.Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }

        public bool Add(T obj)
        {
            return _repository.Insert(obj);
        }
        public async Task<T> Get(Guid id)
        {
            return await _repository.Select(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.SelectAll();
        }

        public bool Update(T obj)
        {
            return _repository.Update(obj);
        }

       
    }
}
