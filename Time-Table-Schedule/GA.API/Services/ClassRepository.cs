using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA.API.DTOs;
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

        public async Task<bool> CreateAsync(Class entity)
        {
            await _db.Classes.AddAsync(entity);
            return await SaveAsync();
        }

        public async Task<bool> Delete(Class entity)
        {
            _db.Classes.Remove(entity);
            return await SaveAsync();
        }

        public async Task<IList<Class>> GetAll()
        {
            var classes = await _db.Classes
               // .Include(p => p.Prof)
                //.Include(c => c.Course)
                .Include(g => g.Groups)
                .ToListAsync();
            return classes;
        }

        

        public async Task<Class> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAsync()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
            ;
        }

        public Task<bool> UpdateAsync(Class entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ClassFilter>> GetAllClassFilter()
        {
            var classes = await _db.Classes.ToListAsync();
            return (IList<ClassFilter>)classes;
        }
    }
}
