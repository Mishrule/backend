using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Services
{
    public class ProfRepository : IProfRepository
    {
        public Task<bool> Create(Prof entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Prof entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Prof>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Prof> FindById(int id)
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

        public Task<bool> Update(Prof entity)
        {
            throw new NotImplementedException();
        }
    }
}
