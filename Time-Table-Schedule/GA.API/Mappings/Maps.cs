using AutoMapper;
using GA.API.Data;
using GA.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Mappings
{
    public class Maps: Profile
    {
        public Maps()
        {
            CreateMap<Class, ClassDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<ProcessData, ProcessDataDto>().ReverseMap();
            CreateMap<Prof, ProfDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
        }
    }
}
