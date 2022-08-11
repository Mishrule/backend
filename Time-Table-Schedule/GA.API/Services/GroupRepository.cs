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

        public async Task<bool> CreateAsync(Group entity, GroupObject groupObject)
        {
   
             var group = new
             {
                 group = groupObject.group
                     //group = groupObject.group


                     //id = groupObject.id,
                     //name = groupObject.name,
                     //size = groupObject.size,
                   
                 
             };

            var serializeGroup = JsonConvert.SerializeObject(group);

            var groupEntity = new Group
            {
                group = serializeGroup
            };

            var groupData = new Dataa
            {
                data = serializeGroup
            };



            await _db.Groups.AddAsync(groupEntity);
            await _db.Datum.AddAsync(groupData);
            return await SaveAsync();
        }

        public async Task<bool> Delete(Group entity)
        {
            _db.Groups.Remove(entity);
            return await SaveAsync();
        }

        public async Task<IList<Group>> GetAll()
        {
            var groups = await _db.Groups.OrderByDescending(o=>o.id).ToListAsync();
            return groups;
        }

        public async Task<Group> GetById(int id)
        {
            var group = await _db.Groups.FirstOrDefaultAsync(g => g.id == id);
            return group;
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Groups.AnyAsync(q => q.id == id);
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

        public async Task<bool> UpdateAsync(Group entity, GroupObject groupObject)
        {
            var data = new GroupObject
            {
                group = groupObject.group
               //id = groupObject.id,
               //name = groupObject.name,
               //size= groupObject.size
            };
            var serialized = JsonConvert.SerializeObject(data);
            entity.id = entity.id;
            entity.group = serialized;


            _db.Groups.Update(entity);
            return await SaveAsync();
        }
    }
}
