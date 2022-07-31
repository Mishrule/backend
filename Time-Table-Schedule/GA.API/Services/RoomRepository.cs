using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Services
{
    public class RoomRepository : IRoomRepository
    {
        public Task<bool> Create(Room entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Room entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Room>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Room> FindById(int id)
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

        public Task<bool> Update(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
