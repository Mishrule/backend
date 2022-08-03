using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Data
{
    
    public class ClassFilter
    {
        public int Id { get; set; }
        
        public int ProfId { get; set; }

        [NotMapped]
        public virtual Prof Prof { get; set; }
        
        public int CourseId { get; set; }

        [NotMapped]
        public virtual Course Course { get; set; }
        public int Duration { get; set; }
        public bool Lab { get; set; }
        // [ForeignKey("Group")]
        
        public int GroupId { get; set; }

        [NotMapped]
        public virtual Group Group { get; set; }
        //[ForeignKey("Group")]
        [NotMapped]
        public virtual List<int> Groups { get; set; }
    }


    public class Class
    {
        public int Id { get; set; }
        public int ProfId { get; set; }
        public int CourseId { get; set; }
        public int Duration { get; set; }
        public bool Lab { get; set; }

        public virtual IList<Group> Groups { get; set; }
    }
        //private readonly List<Group> _groups = new List<Group>();
        //public IReadOnlyList<Group> Groups => _groups.AsReadOnly();

    
}
