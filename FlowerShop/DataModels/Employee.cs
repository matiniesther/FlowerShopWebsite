using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerShop.DataModels
{
    public class Employee
    {
        public int employeeID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string department { get; set; }
    }
}