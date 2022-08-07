﻿using GA.API.Contracts;
using GA.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA.API.DTOs;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        public async Task<bool> CreateAsync(Class entity, ClassObject classObject)
        {
            List<int> groupData = new();
            foreach (var item in classObject.group)
            {
                groupData.Add(item);
            }
            var data = new ClassObject
            {
                professor=classObject.professor,
                course=classObject.course,
                duration=classObject.duration,
                group= groupData,
                lab=classObject.lab
            };
            var classSerialize = JsonConvert.SerializeObject(data);
            entity = new Class
            {
                @class = classSerialize
            };

           var classJson = new Class
            {
                @class = classSerialize
            };
            var classJsonSerialize = JsonConvert.SerializeObject(classJson);
            var serializeRoom = new Dataa
            {
                data = classJsonSerialize
            };

            
            await _db.Classes.AddAsync(entity);
            await _db.Datum.AddAsync(serializeRoom);
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
                .ToListAsync();
          //  string strResultJson = JsonConvert.SerializeObject(classes);
            return classes;
        }



        public  Task<Class> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public  Task<bool> isExists(int id)
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

        public async Task<bool> UpdateAsync(Class entity, ClassObject classObject)
        {
            List<int> groupData = new();
            foreach (var item in classObject.group)
            {
                groupData.Add(item);
            }
            var data = new ClassObject
            {
               professor= classObject.professor,
               course=classObject.course,
               duration=classObject.duration,
               group= groupData,
               lab=classObject.lab
            };
            var serialized = JsonConvert.SerializeObject(data);
            entity.@class = serialized;


            _db.Classes.Update(entity);
            return await SaveAsync();
        }

        
    }



}
