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
            CreateMap<ClassFilter, ClassFilterDto>().ReverseMap();
            CreateMap<ClassFilter, CreateClassFilterDto>().ReverseMap();

            CreateMap<Class, ClassDto>().ReverseMap();
            CreateMap<Class, CreateClassDto>().ReverseMap();

            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            
            CreateMap<ProcessData, ProcessDataDto>().ReverseMap();
            CreateMap<ProcessData, CreateProcessDataDto>().ReverseMap();
            
            CreateMap<Prof, ProfDto>().ReverseMap();
            CreateMap<Prof, CreateProfDto>().ReverseMap();
            
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Room, CreateRoomDto>().ReverseMap();
            
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<Group, CreateGroupDto>().ReverseMap();
            
            CreateMap<ClassFilter, ClassFilterDto>().ReverseMap();


        }
    }
}
