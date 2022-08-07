﻿using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA.API.DTOs;

namespace GA.API.Contracts
{
    
    public interface IClassRepository : IRepositoryBase<Class>
    {
        Task<bool> CreateAsync(Class entity, ClassObject classObject);
        Task<bool> UpdateAsync(Class entity, ClassObject classObject);
    }
}
