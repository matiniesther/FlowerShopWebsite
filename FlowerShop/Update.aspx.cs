using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlowerShop.DBClasses;
using FlowerShop.DataModels;

namespace FlowerShop
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Customer theCustomer = (Customer)Session["CustomerInfo"];
            Customer objCustomer = new Customer();
            objCustomer.firstName = txtFirstName.Text;
            objCustomer.lastName = txtLastName.Text;
            objCustomer.address = txtAddress.Text;
            objCustomer.city = txtCity.Text;
            objCustomer.state = txtState.Text;

            CustomerInformation c1 = new CustomerInformation();
            Button theButton = (Button)sender;

            //selected a random number, my int.Parse(theButton.ID) throws me an error
            c1.updateCustomer(7, txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtCity.Text, txtState.Text, int.Parse(txtZip.Text));
            Response.Redirect("RegistrationConfirmation.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationConfirmation.aspx");
        }
    }
}