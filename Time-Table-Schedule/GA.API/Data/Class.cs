using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Data
{
    [Keyless]
    public class Class
    {
        public int Professor { get; set; }
        public int Course { get; set; }
        public int Duration { get; set; }
        public List<int> Groups { get; set; }
        public bool Lab { get; set; }
        public int GroupID { get; set; }
        public virtual Group Group { get; set; }
    }
}
