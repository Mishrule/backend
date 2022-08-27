using System.ComponentModel.DataAnnotations;

namespace TimeTableUI.Models.VMs
{
    public class Rooms
    {
     
        public string name { get; set; }

  
        public bool lab { get; set; }

     
        public int size { get; set; }
    }

    public class RoomVM
    {
        public Rooms room { get; set; }
    }
}
