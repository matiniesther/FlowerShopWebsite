using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlowerShop.DataModels;

namespace FlowerShop
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected int getCartNumber()
        {
            int itemCount = 0;
            if (Session["flowerCart"] != null)
            {
                ShoppingCart theCart =
                            (ShoppingCart)Session["flowerCart"];
                itemCount = theCart.items.Count;
            }
            return itemCount;
        }

    }
}