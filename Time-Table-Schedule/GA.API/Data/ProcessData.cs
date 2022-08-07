using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Data
{
    public class ProcessData
    {
        //public int Id { get; set; }
        //public int ProfId { get; set; }
        //public virtual Prof Prof { get; set; }
        //public int CourseId { get; set; }
        //public virtual Course Course { get; set; }
        //public int RoomId { get; set; }
        //public virtual Room Room { get; set; }
        ////[NotMapped]
        //public int GroupId { get; set; }
        //public virtual Group Group { get; set; }
        //public int ClassId { get; set; }
        //public virtual Class Class { get; set; }
        public int id { get; set; }
        public int profId { get; set; }
        public Prof prof { get; set; }
        public int courseId { get; set; }
        public Course course { get; set; }
        public int roomId { get; set; }
        public Room room { get; set; }
        public int groupId { get; set; }
        public Group group { get; set; }
        public int classId { get; set; }
        public Class @class { get; set; }
    }
}
