using GA.API.Data;
using GA.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Contracts
{
    public interface IRoomRepository : IRepositoryBase<Room>
    {
        Task<bool> CreateAsync(Room entity, RoomObject roomObject);
        Task<bool> UpdateAsync(Room entity, RoomObject roomObject);
    }
}
