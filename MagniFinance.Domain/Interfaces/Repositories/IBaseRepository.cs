using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MagniFinance.Domain.Entities;

namespace MagniFinance.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Insert(T obj);
        bool Update(T obj);
        bool Delete(Guid id);
        Task<T> Select(Guid id);
        Task<IEnumerable<T>> SelectAll();
    } 
}
