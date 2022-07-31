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
}
