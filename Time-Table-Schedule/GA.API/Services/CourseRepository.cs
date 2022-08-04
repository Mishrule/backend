using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GA.API.Services
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _db;

        public CourseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateAsync(Course entity)
        {
            await _db.Courses.AddAsync(entity);
            return await SaveAsync();
        }

        public async Task<bool> Delete(Course entity)
        {
            _db.Courses.Remove(entity);
            return await SaveAsync();
        }

        public async Task<IList<Course>> GetAll()
        {
            var courses = await _db.Courses.ToListAsync();
            return courses;
        }

        public async Task<Course> GetById(int id)
        {
            if (await isExists(id))
            {
                var course = await _db.Courses.FirstOrDefaultAsync(c => c.Id == id);
                return course;
            }
            else
            {
                return new Course()
                {
                    Name = $"Sorry Nothing Matches the {id} Selected"
                };
            }

            
        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Courses.AnyAsync(c => c.Id == id);
            return isExists;
        }

        public async Task<bool> SaveAsync()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> UpdateAsync(Course entity)
        {
             _db.Courses.Update(entity);
            return await SaveAsync();
        }
    }
}
