using MagniFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagniFinance.Domain.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        bool Add(T obj);
        bool Update(T obj);
        bool Delete(Guid id);
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}