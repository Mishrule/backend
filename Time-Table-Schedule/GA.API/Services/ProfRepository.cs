﻿using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GA.API.Services
{
    public class ProfRepository : IProfRepository
    {
        private readonly ApplicationDbContext _db;
        public ProfRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> CreateAsync(Prof entity)
        {
            await _db.Profs.AddAsync(entity);
            return await SaveAsync();
        }

        public async Task<bool> Delete(Prof entity)
        {
            _db.Profs.Remove(entity);
            return  await SaveAsync();
        }

        public async Task<IList<Prof>> GetAll()
        {
            var profs = await _db.Profs.ToListAsync();
            return profs;
        }

        public async Task<Prof> GetById(int id)
        {
            var prof = await _db.Profs.FirstOrDefaultAsync(p => p.Id == id);
            return prof;
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Profs.AnyAsync(p => p.Id == id);
            return isExists;
        }

        public async Task<bool> SaveAsync()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> UpdateAsync(Prof entity)
        {
            _db.Profs.Update(entity);
            return await SaveAsync();
        }
    }
}
