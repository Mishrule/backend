using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Contracts
{
   public interface IProcessDataRepository : IRepositoryBase<ProcessData>
    {
        Task<IList<ProcessData>> GetFileToJson();
    }
}
