using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Data
{
    
   

    public class Class
    {
        public int id { get; set; }
        public string @class { get; set; }

       // public string Group { get; set; }
        //public virtual IList<Group> Groups { get; set; }
    }
        //private readonly List<Group> _groups = new List<Group>();
        //public IReadOnlyList<Group> Groups => _groups.AsReadOnly();



    
}
