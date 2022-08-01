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

        public async Task<bool> Create(Group entity)
        {
            await _db.Groups.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Group entity)
        {
            _db.Groups.Remove(entity);
            return await Save();
        }

        public async Task<IList<Group>> FindAll()
        {
            var groups = await _db.Groups.ToListAsync();
            return groups;
        }

        public async Task<Group> FindById(int id)
        {
            var group = await _db.Groups.FirstOrDefaultAsync(g => g.Id == id);
            return group;
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Groups.AnyAsync(q => q.Id == id);
            return isExists;
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Group entity)
        {
            _db.Groups.Update(entity);
            return await Save();
        }
    }
}
