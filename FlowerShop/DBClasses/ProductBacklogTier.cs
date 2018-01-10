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
    public class ProductBacklogTier
    {
        private String _ConnectionString;
        private SqlDataReader reader { get; set; }

        public ProductBacklogTier()
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
            Query = "SELECT * FROM ProductBacklog;";

            da = new SqlDataAdapter(Query, this.ConnectionString);
            ds = new DataSet();

            try
            {
                da.Fill(ds, "ProductBacklog");
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

        //gets all the products from the product backlog
        public List<ProductBacklog> getAllProducts()
        {
            List<ProductBacklog> theList = null;
            ProductBacklog theProduct = null;
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
                            theList = new List<ProductBacklog>();
                            while (reader.Read())
                            {
                                theProduct = new ProductBacklog();

                                theProduct.productID = (int)reader["ProductID"];
                                theProduct.productDescription = reader["ProductDescription"].ToString();
                                theProduct.productName = reader["ProductName"].ToString();
                                theProduct.productPrice = (float)reader["ProductPrice"];
                                theProduct.quantityOnHold = (int) reader["QuantityOnHold"];


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

        //get a product from the product backlog given a productID
        public ProductBacklog getProduct(int productID)
        {
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            SqlCommand cmd;
            string query;
            ProductBacklog theProduct;
            SqlDataReader reader;

            query = "SELECT * FROM ProductBacklog WHERE ProductID = @ID;";

            cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = productID;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    theProduct = new ProductBacklog();
                    reader.Read();
                    theProduct.productID = productID;
                    theProduct.productDescription = reader.GetString(1);
                    theProduct.productName = reader.GetString(2);
                    theProduct.productPrice = (float)reader.GetDouble(3);
                    theProduct.quantityOnHold = (int)reader.GetInt32(4);
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



        //inserts products into the product backlog database
        public bool insertProduct(string productDescription, string productName, float productPrice, int quantityOnHold)
        {
            bool success = false;

            int rows;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;


            Query = "INSERT INTO Products (ProductDescription, ProductName, " +
                    "ProductPrice, QuantityOnHold) VALUES(@ProductDescription, " +
                    " @ProductName, @ProductPrice, @QuantityOnHold);";


            conn = new SqlConnection(this.ConnectionString);
            cmd = new SqlCommand(Query, conn);


            cmd.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 50).Value = productDescription;
            cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Value = productName;
            cmd.Parameters.Add("@ProductPrice", SqlDbType.Float).Value = productPrice;
            cmd.Parameters.Add("@QuantitiyOnHold", SqlDbType.Int).Value = quantityOnHold;
           



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

        //updates a product onto the product backlog based on their id
        public Boolean updateProduct(int productID, String productDescription, String productName, float productPrice, int quantityOnHold)
        {
            Boolean Success = false;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;
            int rows;

            Query = "UPDATE ProductBacklog " +
                "SET ProductID = @ProductID, " +
                "ProductDescription = @ProductDescription, productName = @ProductName, " +
                "ProductPrice = @ProductPrice, QuantityOnHold = @QuantityOnHold" +
                "WHERE ProductID = @ProductID;";

            conn = new SqlConnection(this.ConnectionString);
            cmd = new SqlCommand(Query, conn);


            cmd.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 50).Value = productDescription;
            cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Value = productName;
            cmd.Parameters.Add("@ProductPrice", SqlDbType.Float).Value = productPrice;
            cmd.Parameters.Add("@QuantitiyOnHold", SqlDbType.Int).Value = quantityOnHold;


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

        //deletes a product from the productBacklog
        public Boolean deleteCustomer(int productID)
        {
            Boolean Success = false;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;
            int rows;

            Query = "DELETE FROM ProductBacklog WHERE ProductID = @ProductID;";

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
