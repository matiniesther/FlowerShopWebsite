using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using FlowerShop.DBClasses;

namespace FlowerShop
{
    public partial class RegistrationConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            CustomerInformation objCustomer = new CustomerInformation();
            DataSet ds = objCustomer.getDataSet();
            Table theTable = new Table();
            Table eachCustomer;
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
                eachCustomer = buildCustomerTable(row);
                td.Controls.Add(eachCustomer);
                tr.Cells.Add(td);

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
            pnlCustomers.Controls.Add(theTable);

        }

        protected Table buildCustomerTable(DataRow dr)
        {
            Table CustomerTable = new Table();
            TableRow tr;
            TableCell td;
            Label theLabel;
            Button theButton;
            if (dr != null)
            {
                //displays all the first names in the database
                theLabel = new Label();
                tr = new TableRow();
                td = new TableCell();
                theLabel.Text = "<strong> First Name: </Strong>" + dr.ItemArray[1].ToString();
                td.Controls.Add(theLabel);
                td.Style["text-align"] = "center";
                tr.Cells.Add(td);
                CustomerTable.Rows.Add(tr);

                //Displays all the last names in the database
                theLabel = new Label();
                tr = new TableRow();
                td = new TableCell();
                td.Style["width"] = "150px";
                td.Style["word-wrap"] = "break-word";
                theLabel.Text = "<strong>Last Name: </strong> " +  dr.ItemArray[2].ToString();
                td.Controls.Add(theLabel);
                td.Style["text-align"] = "center";
                tr.Cells.Add(td);
                CustomerTable.Rows.Add(tr);

                //Displays all the addresses in the databaae
                theLabel = new Label();
                tr = new TableRow();
                td = new TableCell();
                td.Style["width"] = "150px";
                td.Style["word-wrap"] = "break-word";
                theLabel.Text = "<strong>Address: </strong> " + dr.ItemArray[3].ToString();
                td.Controls.Add(theLabel);
                td.Style["text-align"] = "center";
                tr.Cells.Add(td);
                CustomerTable.Rows.Add(tr);

                //Displays all the city in the database
                theLabel = new Label();
                tr = new TableRow();
                td = new TableCell();
                td.Style["width"] = "150px";
                td.Style["word-wrap"] = "break-word";
                theLabel.Text = "<strong>City: </strong> " + dr.ItemArray[4].ToString();
                td.Controls.Add(theLabel);
                td.Style["text-align"] = "center";
                tr.Cells.Add(td);
                CustomerTable.Rows.Add(tr);

                //Displays all the States in the databbase
                theLabel = new Label();
                tr = new TableRow();
                td = new TableCell();
                td.Style["width"] = "150px";
                td.Style["word-wrap"] = "break-word";
                theLabel.Text = "<strong>State: </strong> " + dr.ItemArray[5].ToString();
                td.Controls.Add(theLabel);
                td.Style["text-align"] = "center";
                tr.Cells.Add(td);
                CustomerTable.Rows.Add(tr);

                // Displays all the zipcode in the database
                theLabel = new Label();
                tr = new TableRow();
                td = new TableCell();
                td.Style["width"] = "150px";
                td.Style["word-wrap"] = "break-word";
                theLabel.Text = "<strong>Zipcode: </strong> " + dr.ItemArray[6].ToString();
                td.Controls.Add(theLabel);
                td.Style["text-align"] = "center";
                tr.Cells.Add(td);
                CustomerTable.Rows.Add(tr);



                td = new TableCell();
                tr = new TableRow();
                theButton = new Button
                {
                    ID = dr.ItemArray[0].ToString(),
                    Text = "Delete "
                };
                theButton.Click += btnDelete_Click;
                theButton.CssClass = "btn btn-success";
                theButton.Style["display"] = "block";
                theButton.Style["margin"] = "auto";
                td.Controls.Add(theButton);
                tr.Cells.Add(td);
                CustomerTable.Rows.Add(tr);

                td = new TableCell();
                tr = new TableRow();
                theButton = new Button
                {
                    ID = dr.ItemArray[1].ToString(),
                    Text = "Update"
                };
                theButton.Click += btnUpdate_Click;
                theButton.CssClass = "btn btn-warning";
                theButton.Style["display"] = "block";
                theButton.Style["margin"] = "auto";
                td.Controls.Add(theButton);
                tr.Cells.Add(td);
                CustomerTable.Rows.Add(tr);

            }
            return CustomerTable;
        }

        //This deletes any information from the user
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CustomerInformation c2 = new CustomerInformation();
            Button theButton = (Button)sender;
            c2.deleteCustomer(int.Parse(theButton.ID));

        }

        //This deals with the update button
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Update.aspx");

        }
    }
   

}






