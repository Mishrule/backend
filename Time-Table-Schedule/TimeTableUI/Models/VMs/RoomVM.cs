using System.ComponentModel.DataAnnotations;

namespace TimeTableUI.Models.VMs
{
    public class RoomVM
    {
        [Required]
        public string name { get; set; }

        [Required]
        public bool lab { get; set; }

        [Required]
        public int size { get; set; }
    }
}
