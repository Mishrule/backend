using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Services
{
    public class ProcessDataRepository : IProcessDataRepository
    {
        public Task<bool> Create(ProcessData entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ProcessData entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ProcessData>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProcessData> FindById(int id)
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

        public Task<bool> Update(ProcessData entity)
        {
            throw new NotImplementedException();
        }
    }
}
