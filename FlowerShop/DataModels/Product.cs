using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerShop.DataModels
{
    public class Product
    {
        public int productID{ get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public float productPrice { get; set; }
        public string productImagePath { get; set; }

    }
}