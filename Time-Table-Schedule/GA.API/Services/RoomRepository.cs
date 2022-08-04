using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GA.API.Services
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _db;
        public RoomRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> CreateAsync(Room entity)
        {
            await _db.Rooms.AddAsync(entity);
            return await SaveAsync();
        }

        public async Task<bool> Delete(Room entity)
        {
            _db.Rooms.Remove(entity);
            return await SaveAsync();
        }

        public async Task<IList<Room>> GetAll()
        {
            var rooms = await _db.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<Room> GetById(int id)
        {
            if (await isExists(id))
            {
                var room = await _db.Rooms.FirstOrDefaultAsync(r => r.Id == id);
                return room;
            }
            else
            {
                return new Room()
                {
                    Name = $"Sorry Nothing Matches the {id} Selected"
                };
            }
        }

        public async Task<Room> FindById(string name)
        {
            if (await isExists(name))
            {
                var room = await _db.Rooms.FirstOrDefaultAsync(r => r.Name == name);
                return room;
            }
            else
            {
                return new Room()
                {
                    Name = $"Sorry Nothing Matches the {name} Selected"
                };
            }
        }

        public async Task<bool> isExists(string name)
        {
            var isExists = await _db.Rooms.AnyAsync(r => r.Name == name);
            return isExists;
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Rooms.AnyAsync(r => r.Id == id);
            return isExists;
        }

        public async Task<bool> SaveAsync()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> UpdateAsync(Room entity)
        {
            _db.Rooms.Update(entity);
            return await SaveAsync();
        }
    }
}
