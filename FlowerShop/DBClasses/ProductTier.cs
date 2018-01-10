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
    public class ProductTier
    {
        private String _ConnectionString;
        private SqlDataReader reader { get; set; }

        public ProductTier()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["MyData"].ToString();
        }
        public String ConnectionString
        {
            get
            {
                return this._ConnectionString;
            }
            set
            {
                this._ConnectionString = value;
            }

        }

        public DataSet getDataSet()
        {
            DataSet ds;
            SqlDataAdapter da;
            String Query;
            Query = "SELECT * FROM Products;";

            da = new SqlDataAdapter(Query, this.ConnectionString);
            ds = new DataSet();

            try
            {
                da.Fill(ds, "Products");
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;

        }
        public byte[] getProductImage(int ProductID)
        {
            byte[] theImage = null;

            return theImage;
        }

        //gets all the products
        public List<Product> getAllProducts()
        {
            List<Product> theList = null;
            Product theProduct = null;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;

            Query = "SELECT * FROM Products;";

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
                            theList = new List<Product>();
                            while (reader.Read())
                            {
                                theProduct = new Product();

                                theProduct.productID = (int)reader["ProductID"];
                                theProduct.productDescription= reader["ProductDescription"].ToString();
                                theProduct.productName= reader["ProductName"].ToString();
                                theProduct.productPrice = (float)reader["ProductPrice"];
                                theProduct.productImagePath = "/Handlers/productHandler.ashx?ID=";
                              

                                theList.Add(theProduct);
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

        //get a product given a productID
        public Product getProduct(int productID)
        {
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            SqlCommand cmd;
            string query;
            Product theProduct;
            SqlDataReader reader;

            query = "SELECT * FROM Products WHERE ProductID = @ID;";

            cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = productID;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    theProduct = new Product();
                    reader.Read();
                    theProduct.productID = productID;
                    theProduct.productDescription = reader.GetString(1);
                    theProduct.productName = reader.GetString(2);
                    theProduct.productPrice = (float)reader.GetDouble(3);
                    theProduct.productImagePath = "/Handlers/productHandler.ashx?ID="
                        + productID.ToString();
                }
                else
                {
                    theProduct = null;
                }
            } 
            catch (SqlException ex)
            {
                throw new Exception("Error getting product ", ex);
            }
            finally
            {
                conn.Close();
            }
            return theProduct;
        } 



        //inserts products into the database
        public bool insertProduct( string productDescription, string productName, float productPrice, byte[] productImage)
        {
            bool success = false;

            int rows;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;


            Query = "INSERT INTO Products (ProductDescription, ProductName, " +
                    "ProductPrice, ProductImage) VALUES(@ProductDescription, " +
                    " @ProductName, @ProductPrice, @ProductImage);";


            conn = new SqlConnection(this.ConnectionString);
            cmd = new SqlCommand(Query, conn);


            cmd.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 50).Value = productDescription;
            cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Value = productName;
            cmd.Parameters.Add("@ProductPrice", SqlDbType.Float).Value = productPrice;
            if(productImage == null)
            {
                cmd.Parameters.Add("@ProductImage", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@ProductImage", SqlDbType.Image).Value = productImage;
            }
            
           
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
                if (rows <= 0)
                {
                    success = false;
                }
                else
                {
                    success = true;
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

            return success;
        }

        //updates a product based on their id
        public Boolean updateProduct(int productID, String productDescription, String productName, float productPrice, byte[] productImage)
        {
            Boolean Success = false;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;
            int rows;

            Query = "UPDATE Products " +
                "SET ProductID = @ProductID, " +
                "ProductDescription = @ProductDescription, productName = @ProductName, " +
                "ProductPrice = @ProductPrice, ProductImage = @ProductImage " +
                "WHERE ProductID = @ProductID;";

            conn = new SqlConnection(this.ConnectionString);
            cmd = new SqlCommand(Query, conn);


            cmd.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 50).Value = productDescription;
            cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Value = productName;
            cmd.Parameters.Add("@ProductPrice", SqlDbType.Float).Value = productPrice;
            if (productImage == null)
            {
                cmd.Parameters.Add("@ProductImage", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@ProductImage", SqlDbType.Image).Value = productImage;
            }

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

        //deletes a product
        public Boolean deleteCustomer(int productID)
        {
            Boolean Success = false;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;
            int rows;

            Query = "DELETE FROM Products WHERE ProductID = @ProductID;";

            conn = new SqlConnection(this.ConnectionString);
            cmd = new SqlCommand(Query, conn);

            cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

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
