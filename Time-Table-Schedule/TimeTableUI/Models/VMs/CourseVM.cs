namespace TimeTableUI.Models.VMs
{
   

    //public class Course
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //}

    //public class CourseVM
    //{
    //    public Course course { get; set; }
    //}



    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class CourseVM
    {
        public Course @course { get; set; }
    }
}
