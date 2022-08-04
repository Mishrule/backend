﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Data
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Lab { get; set; }
        public int Size { get; set; }
    }
}
