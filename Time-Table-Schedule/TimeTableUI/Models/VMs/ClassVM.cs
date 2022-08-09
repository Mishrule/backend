using System.Collections.Generic;

namespace TimeTableUI.Models.VMs
{


    public class Class
    {
        public int professor { get; set; }
        public int course { get; set; }
        public int duration { get; set; }
        public List<int> group { get; set; }
        public bool lab { get; set; }
    }

    public class ClassVM
    {
        public Class @class { get; set; }
    }
}

