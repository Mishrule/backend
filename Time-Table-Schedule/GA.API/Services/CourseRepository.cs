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

        public async Task<bool> CreateAsync(Course entity, CourseObject courseObject)
        {
            var data = new CourseObject
            {
                id = courseObject.id,
                name=courseObject.name
            };
            var courseSerialize = JsonConvert.SerializeObject(data);
            entity = new Course
            {
                course = courseSerialize
            };
            var courseJson = new Course
            {
                course = courseSerialize
            };
            var courseJsonSerialize = JsonConvert.SerializeObject(courseJson);
            var serializeCourse = new Dataa
            {
                data = courseJsonSerialize
            };
            await _db.Courses.AddAsync(entity);
            await _db.Datum.AddAsync(serializeCourse);
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
                var course = await _db.Courses.FirstOrDefaultAsync(c => c.id == id);
                return course;
            }
            else
            {
                return new Course()
                {course= $"Sorry Nothing Matches the {id} Selected"
                };
            }


        }

        public async Task<bool> isExists(int id)
        {
            var isExists = await _db.Courses.AnyAsync(c => c.id == id);
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

        public async Task<bool> UpdateAsync(Course entity, CourseObject courseObject)
        {
            var data = new CourseObject
            {
                id = courseObject.id,
                name = courseObject.name
            };
            var serialized = JsonConvert.SerializeObject(data);
            entity.course = serialized;
            entity.id = entity.id;
            

            _db.Courses.Update(entity);
            return await SaveAsync();
        }
    }
}
