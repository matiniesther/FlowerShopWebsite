using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlowerShop.DataModels;
using FlowerShop.DBClasses;

namespace FlowerShop.DataModels
{
    public class ShoppingCart
    {
        public int count { get; set; }
        public List<Product> items { get; set; }

        public ShoppingCart()
        {
            items = new List<Product>();
            count = 0;
        }

        public void addItem(int id)
        {
            Product theItem;
            ProductTier theTier = new ProductTier();

            theItem = theTier.getProduct(id);
            if (theItem != null)
            {
                items.Add(theItem);
                count = items.Count;
            }

        }

        public void removeItem(int id)
        {
            Product theItem =
                items.SingleOrDefault<Product>(item => item.id == id);
            if (theItem != null)
            {
                items.Remove(theItem);
                count = items.Count;
            }

        }

        public float getSubTotal()
        {
            float subTotal = (float)0.0;

            foreach (Product item in items)
            {
                subTotal += item.productPrice;
            }

            return subTotal;
        }



    }
}