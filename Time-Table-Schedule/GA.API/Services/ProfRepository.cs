using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GA.API.DTOs;
using Newtonsoft.Json;

namespace GA.API.Services
{
    

    public class ProfRepository : IProfRepository
    {
        private readonly ApplicationDbContext _db;
       // public Prof entity { get; set; }
        public ProfRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> CreateAsync(Prof entity)
        {
            await _db.Profs.AddAsync(entity);
            return await SaveAsync();
        }

        public async Task<bool> CreateAsync(Prof entity, ProfObject profObject)
        {
            
            var prof = new
            {
                prof = new Prof
                {
                    id = profObject.prof.id,
                    name = profObject.prof.name
                }
            };
            var serializeProf = JsonConvert.SerializeObject(prof);

            var profEntity = new Prof
            {
                name = serializeProf
            };

            var profData = new Dataa
            {
                data = serializeProf
            };
            
            await _db.Profs.AddAsync(profEntity);
            await _db.Datum.AddAsync(profData);
            return await SaveAsync();
        }

       
        public async Task<bool> Delete(Prof entity)
        {
            _db.Profs.Remove(entity);
            return await SaveAsync();
        }

        public async Task<IList<Prof>> GetAll()
        {
            var profs = await _db.Profs.OrderByDescending(q=>q.id).ToListAsync();
            
            return profs;
        }

        public async Task<Prof> GetById(int id)
        {
            var prof = await _db.Profs.FirstOrDefaultAsync(p => p.id == id);
            return prof;
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Profs.AnyAsync(p => p.id == id);
            return isExists;
        }

        public async Task<bool> SaveAsync()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> UpdateAsync(Prof entity, ProfObject profObject)
        {
            var data = new ProfObject
            {
                prof = profObject.prof
                //id = profObject.id,
                //name = profObject.name
            };
            var name = JsonConvert.SerializeObject(data);
            entity = new Prof
            {
                id= data.prof.id,
                name = name
            };


            _db.Profs.Update(entity);
            return await SaveAsync();
        }

        public Task<bool> UpdateAsync(Prof entity)
        {
            throw new NotImplementedException();
        }
    }




}
