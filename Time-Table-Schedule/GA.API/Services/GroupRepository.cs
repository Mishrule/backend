using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Services
{
    public class GroupRepository : IGroupRepository
    {
        public Task<bool> Create(Group entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Group entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Group>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Group> FindById(int id)
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

        public Task<bool> Update(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
