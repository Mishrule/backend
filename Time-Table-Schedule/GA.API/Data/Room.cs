﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.Data
{
    public class Room
    {
        public int id { get; set; }
        public string room { get; set; }

        public static implicit operator Room(string v)
        {
            throw new NotImplementedException();
        }
        //public bool Lab { get; set; }
        //public int Size { get; set; }
    }



}
