namespace TimeTableUI.Models.VMs
{
   

    public class Group
    {
        public int id { get; set; }
        public string name { get; set; }
        public int size { get; set; }
    }

    public class GroupVM
    {
        public Group group { get; set; }
    }
}
