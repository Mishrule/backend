using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.DTOs
{
    //public class RoomDto: CreateRoomDto
    //{
    //    public int Id { get; set; }

    //}

    public class CreateRoomDto
    {
        public string Name { get; set; }
        public bool Lab { get; set; }
        public int Size { get; set; }
    }
}
