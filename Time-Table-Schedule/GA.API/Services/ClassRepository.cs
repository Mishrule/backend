using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Services
{
    public class ClassRepository : IClassRepository
    {
        public Task<bool> Create(Class entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Class entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Class>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Class> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Class entity)
        {
            throw new NotImplementedException();
        }
    }
}
