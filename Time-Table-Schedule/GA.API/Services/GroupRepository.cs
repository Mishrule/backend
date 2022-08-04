using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GA.API.Services
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _db;

        public GroupRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateAsync(Group entity)
        {
            await _db.Groups.AddAsync(entity);
            return await SaveAsync();
        }

        public async Task<bool> Delete(Group entity)
        {
            _db.Groups.Remove(entity);
            return await SaveAsync();
        }

        public async Task<IList<Group>> GetAll()
        {
            var groups = await _db.Groups.ToListAsync();
            return groups;
        }

        public async Task<Group> GetById(int id)
        {
            var group = await _db.Groups.FirstOrDefaultAsync(g => g.Id == id);
            return group;
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Groups.AnyAsync(q => q.Id == id);
            return isExists;
        }

        public async Task<bool> SaveAsync()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> UpdateAsync(Group entity)
        {
            _db.Groups.Update(entity);
            return await SaveAsync();
        }
    }
}
