using GA.API.Data;
using GA.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Contracts
{
   public interface IProfRepository : IRepositoryBase<Prof>
    {
        Task<bool> CreateAsync(Prof entity, ProfObject profObject);
        Task<bool> UpdateAsync(Prof entity, ProfObject profObject);
    }
}
