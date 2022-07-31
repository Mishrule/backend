using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Services
{
    public class CourseRepository : ICourseRepository
    {
        public Task<bool> Create(Course entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Course entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Course>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Course> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
