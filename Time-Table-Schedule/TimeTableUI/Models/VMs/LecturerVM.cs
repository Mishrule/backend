namespace TimeTableUI.Models.VMs
{
    public class LecturerVM
    {
        public int id { get; set; }
        public string name { get; set; }
    }

   

    public class RootLecturerVM
    {
        public LecturerVM prof { get; set; }
    }
}
