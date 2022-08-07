using GA.API.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Data
{
   // [Serializable]
    public class Prof
    {
        public int id { get; set; }
        
        public string name { get; set; }
        //[NotMapped]
        //public ProfObject profs { get; set; }
    }


}
