using System;
using System.Data;
using System.Data.SqlClient;

namespace Tehtava9
{
    public class DBViini
    {
        public static DataTable GetAllCustomers(string connectionStr, out string message)
        {
            try
            {
                SqlConnection myConn = new SqlConnection(connectionStr);
                myConn.Open();
                string sql = "SELECT id, firstname, lastname, address, zip, city FROM customer";
                SqlCommand cmd = new SqlCommand(sql, myConn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "customer");
                message = "Data fetched successfully from " + myConn.DataSource;
                myConn.Close();
                return ds.Tables["customer"];
            }
            catch (Exception ex)
            {
                message = ex.Message;
                throw;
            }
        }

        public static void AddNewCustomer(string connectionStr, string firstname, string lastname, string address, string zipcode, string city, out string message)
        {
            try
            {
                SqlConnection myConn = new SqlConnection(connectionStr);
                myConn.Open();
                string sql = string.Format("INSERT INTO customer (firstname, lastname, address, zip, city) VALUES ('{0}','{1}','{2}','{3}','{4}')", firstname, lastname, address, zipcode, city);
                SqlCommand cmd = new SqlCommand(sql, myConn);
                cmd.ExecuteNonQuery();
                myConn.Close();
                message = "Data inserted successfully into " + myConn.DataSource;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                throw;
            }
        }

        public static void DeleteCustomer(string connectionStr, string id, out string message)
        {
            try
            {
                SqlConnection myConn = new SqlConnection(connectionStr);
                myConn.Open();
                string sql = string.Format("DELETE FROM customer WHERE id = '{0}'", id);
                SqlCommand cmd = new SqlCommand(sql, myConn);
                cmd.ExecuteNonQuery();
                myConn.Close();
                message = "Customers id " + id + " deleted successfully";
            }
            catch (Exception ex)
            {
                message = ex.Message;
                throw;
            }
        }
    }
}
