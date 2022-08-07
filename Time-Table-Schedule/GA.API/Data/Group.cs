using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Data
{
    public class Group
    {
        public int id { get; set; }
        public string group { get; set; }
        //public int ClassId { get; set; }
        ////public Class Class { get; set; }

        //public string Name { get; set; }
        //public int Size { get; set; }
    }



}
