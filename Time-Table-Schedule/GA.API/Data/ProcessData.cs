using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Data
{
    [Keyless]
    public class ProcessData
    {
        public int ProfId { get; set; }
        public virtual Prof Prof { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual Room Room { get; set; }
        [NotMapped]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public int ClassesId { get; set; }
        public virtual Class Classes { get; set; }
    }
}
