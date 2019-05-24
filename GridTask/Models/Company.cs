using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GridTask.Models
{
    public class Company
    {
        public int Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public bool Checkbox1 { get; set; }
        public bool Checkbox2 { get; set; }
    }

    public class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }      
    }
}