using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace GA.API.Services
{
    public class ProcessDataRepository : IProcessDataRepository
    {
        private readonly ApplicationDbContext _db;
        public ProcessDataRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> CreateAsync(ProcessData entity)
        {

            await _db.Datas.AddAsync(entity);
            return await SaveAsync();
        }

        public Task<bool> Delete(ProcessData entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ProcessData>> GetAll()
        {
            var data = await _db.Datas.Include(c => c.course)
                .Include(p => p.prof)
                .Include(co => co.course)
                .Include(r => r.room)
                .Include(g => g.group)
                .Include(c => c.@class)
                .ToListAsync();
            return data;
        }

        public async Task<IList<ProcessData>> GetFileToJson()
        {
            var data = await _db.Datas.Include(c => c.course)
                .Include(p => p.prof)
                .Include(co => co.course)
                .Include(r => r.room)
                .Include(g => g.group)
                .Include(c => c.@class)

                .ToListAsync();

          //  string strResultJson = JsonConvert.SerializeObject(data);
            //JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, JsonElement>>[]>(File.ReadAllText("GaSchedule.json"));
          //  File.WriteAllText(@"C:\Users\mishr\source\repos\Mishrule\backend\Time-Table-Schedule\GaSchedule.Console\GaSchedule.json",
              //  strResultJson);
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

        public async Task<bool> SaveAsync()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public Task<bool> UpdateAsync(ProcessData entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Dataa>> GetData()
        {
            var data = await _db.Datum.ToArrayAsync();
            return data;
        }
    }
}
