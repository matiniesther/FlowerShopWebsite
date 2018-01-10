using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.ProviderBase;
using System.Configuration;
using System.Web.UI.WebControls;
using FlowerShop.DataModels;
using FlowerShop.DBClasses;

namespace FlowerShop
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductTier objProduct = new ProductTier();
            DataSet ds = objProduct.getDataSet();
            Table theTable = new Table();
            Table eachProduct;
            TableRow tr = new TableRow();
            TableCell td;
            int counter = 0;

            theTable.Style["margin"] = "0px auto";
            theTable.Style["float"] = "none";

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (counter == 0)
                {
                    tr = new TableRow();
                }
                td = new TableCell();
                td.Style["vertical-align"] = "bottom";
                td.Style["padding"] = "10px";
                eachProduct = buildProductTable(row);
                td.Controls.Add(eachProduct);
                tr.Cells.Add(td);
                theTable.Rows.Add(tr);
                if (counter == 2)
                {
                    theTable.Rows.Add(tr);
                    counter = 0;
                }
                else
                {
                    counter++;
                }
            }

            if (counter <= 2)
            {
                theTable.Rows.Add(tr);
            }
            pnlProducts.Controls.Add(theTable);
        }

        protected Table buildProductTable(DataRow dr)
        {
            Table productTable = new Table();
            TableRow tr;
            TableCell td;
            Label theLabel;
            Image theImage = new Image();
            Button theButton;
            if (dr != null)
            {
                theLabel = new Label();
                tr = new TableRow();
                td = new TableCell();
                theLabel.Text = "<strong>" + dr.ItemArray[1].ToString() +
                       "</strong>";
                td.Controls.Add(theLabel);
                td.Style["text-align"] = "center";
                tr.Cells.Add(td);
                productTable.Rows.Add(tr);

                /* tr = new TableRow();
                 td = new TableCell();
                 theImage.ImageUrl = "/Handlers/productHandler.ashx?ID=" +
                     dr.ItemArray[0].ToString();
                 theImage.Width = 150;
                 theImage.Height = 150;
                 td.Controls.Add(theImage);
                 tr.Cells.Add(td);
                 productTable.Rows.Add(tr);*/


                theLabel = new Label();
                tr = new TableRow();
                td = new TableCell();
                theLabel.Text = "<strong>Description:</strong><br /> " +
                             dr.ItemArray[2].ToString();
                td.Controls.Add(theLabel);
                tr.Cells.Add(td);
                productTable.Rows.Add(tr);


                theLabel = new Label();
                tr = new TableRow();
                td = new TableCell();
                td.Style["width"] = "150px";
                td.Style["word-wrap"] = "break-word";
                theLabel.Text = "<strong>Price:</strong> " +
                          string.Format("{0:#.00}",
                      Convert.ToDecimal(dr.ItemArray[3]));
                td.Controls.Add(theLabel);
                td.Style["text-align"] = "center";
                tr.Cells.Add(td);
                productTable.Rows.Add(tr);


                td = new TableCell();
                tr = new TableRow();
                theButton = new Button
                {
                    ID = dr.ItemArray[0].ToString(),
                    Text = "Add To Cart"
                };
                theButton.Click += addToCart_Click;
                theButton.CssClass = "btn btn-success";
                theButton.Style["display"] = "block";
                theButton.Style["margin"] = "auto";
                td.Controls.Add(theButton);
                tr.Cells.Add(td);
                productTable.Rows.Add(tr);
            }
            return productTable;
        }

        protected void addToCart_Click(object sender, EventArgs e)
        {
            Button theButton = (Button)sender;
            ShoppingCart theCart;

            if (Session["hardwareCart"] == null)
            {
                theCart = new ShoppingCart();
                Session["flowerCart"] = theCart;
            }
            else
            {
                theCart = (ShoppingCart)Session["flowerCart"];
            }
            theCart.addItem(int.Parse(theButton.ID));

        }
    }



}
