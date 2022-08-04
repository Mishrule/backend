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
        public int Id { get; set; }
        public int ProfId { get; set; }
        public virtual Prof Prof { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        //[NotMapped]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
