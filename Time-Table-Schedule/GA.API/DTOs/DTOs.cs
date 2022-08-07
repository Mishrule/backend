using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.DTOs
{
    public class ClassDto
    {
        public int id { get; set; }
        public string @class { get; set; }

    }

    public class CourseDto
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class GroupDto
    {
        public int id { get; set; }
        public string group { get; set; }
    }

    public class ProcessDataDto
    {
        public int id { get; set; }
        public int profId { get; set; }
        public ProfDto prof { get; set; }
        public int courseId { get; set; }
        public CourseDto course { get; set; }
        public int roomId { get; set; }
        public RoomDto room { get; set; }
        public int groupId { get; set; }
        public GroupDto group { get; set; }
        public int classId { get; set; }
        public ClassDto @class { get; set; }
    }

    public class GetDataDto
    {
        //public int id { get; set; }
        //public int profId { get; set; }
        public ProfDto prof { get; set; }
        //public int courseId { get; set; }
        public CourseDto course { get; set; }
        //public int roomId { get; set; }
        public RoomDto room { get; set; }
        //public int groupId { get; set; }
        public GroupDto group { get; set; }
        //public int classId { get; set; }
        public ClassDto @class { get; set; }
    }

    public class CreateProcessDataDto
    {
        public int profId { get; set; }
        public int courseId { get; set; }
        public int roomId { get; set; }
        public int groupId { get; set; }
        public int classId { get; set; }
    }

    // [Serializable]
    public class ProfDto
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class RoomDto
    {
        public int id { get; set; }
        public string room { get; set; }
    }

    public class DataClass
    {
        public int id { get; set; }
        public object data { get; set; }
    }




}
