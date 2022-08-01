using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GA.API.Services
{
    public class ClassRepository : IClassRepository
    {
        private readonly ApplicationDbContext _db;

        public ClassRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Class entity)
        {
            await _db.Classes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Class entity)
        {
            _db.Classes.Remove(entity);
            return await Save();
        }

        public async Task<IList<Class>> FindAll()
        {
            var books = await _db.Classes
                .Include(p => p.Professor)
                .Include(c => c.Course)
                .Include(g => g.Group)
                .ToListAsync();
            return books;
        }

        public async Task<Class> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Class entity)
        {
            throw new NotImplementedException();
        }
    }
}
