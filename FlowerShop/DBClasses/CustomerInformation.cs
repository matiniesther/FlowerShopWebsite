using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.ProviderBase;
using System.Configuration;
using FlowerShop.DataModels;

namespace FlowerShop.DBClasses
{
    public class CustomerInformation
    {
        private String _ConnectionString;
        private SqlDataReader reader { get; set; }

        public CustomerInformation()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["MyData"].ToString();
        }
        public String ConnectionString
        {
            get {
                return this._ConnectionString;
            }
            set {
                this._ConnectionString=value;
            }
            
        }
        public DataSet getDataSet()
        {
            DataSet ds;
            SqlDataAdapter da;
            String Query;
            Query = "SELECT * FROM CustomerInformation;";

            da = new SqlDataAdapter(Query, this.ConnectionString);
            ds = new DataSet();

            try
            {
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;

        }

        //inserts a customer into the database
        public Boolean insertCustomer(String FirstName, String LastName, String Address, String City, String State, int Zip)
        {
            Boolean Success = false;
            int rows;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;

            
            Query = "INSERT INTO CustomerInformation (FirstName, LastName, " +
                    "Address, State, City, Zip) VALUES(@FirstName, " +
                    " @LastName, @Address, @City, @State, @Zip);";

          
            conn = new SqlConnection(this.ConnectionString);
            cmd = new SqlCommand(Query, conn);
            
     
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = LastName;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = Address;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = City;
            cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = State;
            cmd.Parameters.Add("@Zip", SqlDbType.Int).Value = Zip;

          
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    Success = false;
                }
                else
                {
                    Success = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return Success;
        }

        //gets all the Customers
        public List<Customer> getAllCustomers()
        {
            List<Customer> theList = null;
            Customer theCustomer = null;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;

            Query = "SELECT * FROM CustomerInformation;";

            using (conn = new SqlConnection(this.ConnectionString))
            using (cmd = new SqlCommand(Query, conn))
            {
                try
                {
                    conn.Open();

                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            theList = new List<Customer>();
                            while (reader.Read())
                            {
                                theCustomer = new Customer();

                                theCustomer.custID = (int)reader["CustID"];
                                theCustomer.firstName = reader["FirstName"].ToString();
                                theCustomer.lastName = reader["LastName"].ToString();
                                theCustomer.address = reader["Address"].ToString();
                                theCustomer.city = reader["City"].ToString();
                                theCustomer.state = reader["State"].ToString();
                                theCustomer.zipCode = (int)reader["Zip"];

                                theList.Add(theCustomer);
                            }
                        }
                    }

                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }


            return theList;
        }


     

        //updates a customer's information
        public Boolean updateCustomer( int CustID, String FirstName, String LastName, String Address, String City, String State, int Zip)
        {
            Boolean Success = false;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;
            int rows;

            Query = "UPDATE CustomerInformation " +
                "SET FirstName = @FirstName, " +
                "LastName = @LastName, Address = @Address, " +
                "City = @City, State = @State, Zip = @Zip " +
                "WHERE CustID = @CustID;";

            conn = new SqlConnection(this.ConnectionString);
            cmd = new SqlCommand(Query, conn);

            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = LastName;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = Address;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = City;
            cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = State;
            cmd.Parameters.Add("@Zip", SqlDbType.Int).Value = Zip;
            cmd.Parameters.Add("@CustID", SqlDbType.Int).Value = CustID;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    Success = false;
                }
                else
                {
                    Success = true;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return Success;
        }

        //deletes a customer
        public Boolean deleteCustomer(int CustID)
        {
            Boolean Success = false;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;
            int rows;

            Query = "DELETE FROM CustomerInformation WHERE CustID = @CustID;";

            conn = new SqlConnection(this.ConnectionString);
            cmd = new SqlCommand(Query, conn);

            cmd.Parameters.Add("@CustID", SqlDbType.Int).Value = CustID;

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    Success = false;
                }
                else
                {
                    Success = true;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return Success;
        }

    }
}