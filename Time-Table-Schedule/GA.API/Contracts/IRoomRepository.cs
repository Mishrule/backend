using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Contracts
{
    public interface IRoomRepository : IRepositoryBase<Room>
    {
        Task<bool> isExists(string name);
        Task<Room> FindById(string name);
    }
}
