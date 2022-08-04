using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Contracts
{
    public interface IRepositoryBase<T> where T: class
    {
         Task<IList<T>> GetAll();
    Task<T> GetById(int id);
    Task<bool> isExists(int id);
    Task<bool> CreateAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> Delete(T entity);
    Task<bool> SaveAsync();
    }
}
