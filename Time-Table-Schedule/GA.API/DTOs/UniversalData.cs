using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA.API.DTOs
{
   
    //public class 
    //{
    //    public int professor { get; set; }
    //    public int course { get; set; }
    //    public int duration { get; set; }
    //    public List<int> group { get; set; }
    //    public bool lab { get; set; }
    //   // public GroupObject group { get; set; }
    //}

    public class Classe
    {
        public int professor { get; set; }
        public int course { get; set; }
        public int duration { get; set; }
        public List<int> group { get; set; }
        public bool lab { get; set; }
    }

    public class ClassObject
{
        public Classe @class { get; set; }
    }


    


    public class Coursee
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class CourseObject
    {
        public Coursee course { get; set; }
    }




    public class Groupp
    {
        public int id { get; set; }
        public string name { get; set; }
        public int size { get; set; }
    }

    public class GroupObject
    {
        public Groupp group { get; set; }
    }
    //public class ProfObject
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //}

    public class LecturerVM
    {
        public int id { get; set; }
        public string name { get; set; }
    }



    public class ProfObject
    {
        public LecturerVM prof { get; set; }
    }

    public class RoomData
    {
        public string name { get; set; }
        public bool lab { get; set; }
        public int size { get; set; }
    }

    public class RoomObject
    {
        public RoomData room { get; set; }
    }

    public class RootObject
    {
        public ProfDto prof { get; set; }
        public CourseDto course { get; set; }
        public RoomDto room { get; set; }
        public GroupDto group { get; set; }
        public ClassDto @class { get; set; }
    }
}
