using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlowerShop.DataModels;
using FlowerShop.DBClasses;
namespace FlowerShop
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int zipCode;
            Customer objCustomer = new Customer();
            objCustomer.firstName = txtFirstName.Text;
            objCustomer.lastName = txtLastName.Text;
            objCustomer.address = txtAddress.Text;
            objCustomer.city = txtCity.Text;
            objCustomer.state = txtState.Text;


            CustomerInformation c1 = new CustomerInformation();
            c1.insertCustomer(txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtCity.Text, txtState.Text, int.Parse(txtZip.Text));
            try
            {
                zipCode = int.Parse(txtZip.Text);
                objCustomer.zipCode = zipCode;
            }
            catch (FormatException ex)
            {
                throw new FormatException("Error with Zip Code: " + ex.Message);
            }
            Session["CustomerRegistration"] = objCustomer;
            Response.Redirect("RegistrationConfirmation.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtCity.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtState.Text = "";
            txtZip.Text = "";

            Response.Redirect("Home.aspx");
        }
    }
}