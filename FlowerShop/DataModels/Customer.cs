using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerShop.DataModels
{
    public class Customer
    {
        public int custID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
    }
}