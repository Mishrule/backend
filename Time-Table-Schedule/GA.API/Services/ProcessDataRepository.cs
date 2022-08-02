using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GA.API.Services
{
    public class ProcessDataRepository : IProcessDataRepository
    {
        private readonly ApplicationDbContext _db;
        public ProcessDataRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<bool> CreateAsync(ProcessData entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ProcessData entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ProcessData>> GetAll()
        {
            var data = await _db.Datas.Include(c=>c.Course)
                .Include(p=>p.Prof)
                .Include(co => co.Course)
                .Include(r=>r.Room)
                .Include(g=>g.Group)
                .Include(c=>c.Class)
                .ToListAsync();
            return data;
        }

        public Task<ProcessData> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ProcessData entity)
        {
            throw new NotImplementedException();
        }
    }
}
