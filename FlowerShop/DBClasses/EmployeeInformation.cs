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
    public class EmployeeInformation
    {
        private String _ConnectionString;
        private SqlDataReader reader { get; set; }

        public EmployeeInformation()
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
            Query = "SELECT * FROM EmployeeInformation;";

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

        //inserts an employee into the database
        public Boolean insertEmployee(String FirstName, String LastName, String Department)
        {
            Boolean Success = false;
            int rows;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;


            Query = "INSERT INTO EmployeeInformation (FirstName, LastName, " +
                    "Department) VALUES(@FirstName, " +
                    " @LastName, @Department);";


            conn = new SqlConnection(this.ConnectionString);
            cmd = new SqlCommand(Query, conn);


            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = LastName;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar, 50).Value = Department;
            
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

        //gets all the Employees
        public List<Employee> getAllEmployees()
        {
            List<Employee> theList = null;
            Employee theEmployee = null;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;

            Query = "SELECT * FROM EmployeeInformation;";

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
                            theList = new List<Employee>();
                            while (reader.Read())
                            {
                                theEmployee = new Employee();

                                theEmployee.employeeID= (int)reader["EmployeeID"];
                                theEmployee.firstName = reader["FirstName"].ToString();
                                theEmployee.lastName = reader["LastName"].ToString();
                                theEmployee.department= reader["Department"].ToString();
                             

                                theList.Add(theEmployee);
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




        //updates an employee's information
        public Boolean updateEmployee(int EmployeeID, String FirstName, String LastName, String Department)
        {
            Boolean Success = false;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;
            int rows;

            Query = "UPDATE EmployeeInformation " +
                "SET FirstName = @FirstName, " +
                "LastName = @LastName, Department = @Department " +
                "WHERE EmployeeID = @EmployeeID;";

            conn = new SqlConnection(this.ConnectionString);
            cmd = new SqlCommand(Query, conn);

            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = LastName;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar, 50).Value = Department;
            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;

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

        //deletes an employee
        public Boolean deleteEmployee(int EmployeeID)
        {
            Boolean Success = false;
            String Query;
            SqlConnection conn;
            SqlCommand cmd;
            int rows;

            Query = "DELETE FROM EmployeeInformation WHERE EmployeeID = @EmployeeID;";

            conn = new SqlConnection(this.ConnectionString);
            cmd = new SqlCommand(Query, conn);

            cmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = EmployeeID;

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