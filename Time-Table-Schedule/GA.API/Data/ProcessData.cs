using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Data
{
    [Keyless]
    [NotMapped]
    public class ProcessData
    {
      //  [NotMapped]
        public virtual Prof Prof { get; set; }
      //  [NotMapped]
        public virtual Course Course { get; set; }
      //  [NotMapped]
        public virtual Room Room { get; set; }
      //  [NotMapped]
        public virtual Group Group { get; set; }
      //  [NotMapped]
        public virtual Class Class { get; set; }
    }
}
