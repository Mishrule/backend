using GA.API.Data;
using GA.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Contracts
{
   public interface ICourseRepository: IRepositoryBase<Course>
    {
        Task<bool> CreateAsync(Course entity, CourseObject courseObject);
        Task<bool> UpdateAsync(Course entity, CourseObject courseObject);
    }
}
