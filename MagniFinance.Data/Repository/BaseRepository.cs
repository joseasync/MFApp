using MagniFinance.Data.Context;
using MagniFinance.Domain.Entities;
using MagniFinance.Domain.Interfaces;
using MagniFinance.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MagniFinance.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ConnectionContext _connection;

        public BaseRepository(ConnectionContext connection)
        {
            _connection = connection;
        }

        public bool Insert(T obj)
        {
            try
            {
                _connection.Set<T>().Add(obj);
                _connection.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
                return false;
            }
        }

        public bool Update(T obj)
        {
            try
            {
                _connection.Entry<T>(obj).State = System.Data.Entity.EntityState.Modified;
                _connection.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                _connection.Set<T>().Remove(Select(id).Result);
                _connection.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
                throw e;
                
            }
        }

        public async Task<T> Select (Guid id)
        {
            try
            {
                var result = await _connection.Set<T>().FindAsync(id);
                return result;
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
                throw e;

            }
        }

        public async Task<IEnumerable<T>> SelectAll()
        {
            try
            {
                return await _connection.Set<T>().ToListAsync();
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
                throw e;
            }
        }
    }
}
