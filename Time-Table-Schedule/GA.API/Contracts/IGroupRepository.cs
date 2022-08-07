using GA.API.Data;
using GA.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Contracts
{
   public interface IGroupRepository : IRepositoryBase<Group>
    {
        Task<bool> CreateAsync(Group entity, GroupObject groupObject);
        Task<bool> UpdateAsync(Group entity, GroupObject groupObject);
    }
}
