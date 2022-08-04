using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.DTOs
{
    public class ProcessDataDto
    {
       
        public virtual ProfDto Prof { get; set; }
        
        public virtual CourseDto Course { get; set; }
        
        public virtual RoomDto Room { get; set; }
        
        public virtual GroupDto Group { get; set; }
        
        public virtual ClassDto Class { get; set; }
    }

    public class CreateProcessDataDto
    {
        public int ProfId { get; set; }
        public int CourseId { get; set; }
        public int RoomId { get; set; }
        public int GroupId { get; set; }
        public int ClassId { get; set; }
    }
}
