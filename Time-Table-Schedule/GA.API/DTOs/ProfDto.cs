using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.DTOs
{
    public class ProfDto: CreateProfDto
    {
        public int Id { get; set; }
       
    }

    public class CreateProfDto
    {
        public string Name { get; set; }
    }
}
