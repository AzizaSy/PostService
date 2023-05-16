using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Z.Dapper.Plus;

namespace DreamsGH.Classes
{
    public static class Access
    {
        // Getters

        public static string GetNextCustomerID()
        {
            using (SqlConnection cn = new SqlConnection(DB.ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT [dbo].[GetNextCustomerID]()", cn);
                return cmd.ExecuteScalar().ToString();
            }
        }

        public static string GetNextOrderID()
        {
            using (SqlConnection cn = new SqlConnection(DB.ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT [dbo].[GetNextOrderID]()", cn);
                return cmd.ExecuteScalar().ToString();
            }
        }

        public static DataTable GetCustomerTable()
        {
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Customers;", cnn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetCustomerTable(string key, bool IsInteger = false)
        {
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                string query = $"SELECT * FROM Customers WHERE FirstName = '{key}' OR LastName = '{key}' OR Phone = '{key}' OR City = '{key}' OR Convert(VARCHAR,Address) = '{key}'";
                if (IsInteger)
                {
                    query = $"SELECT * FROM Customers WHERE Id = {Convert.ToInt32(key)}";
                }
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetOrderTable()
        {
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                string query = $"SELECT * FROM Orders";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetOrderTable(string key, bool IsInteger = false)
        {
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                string query = $"SELECT * FROM Orders WHERE  Convert(VARCHAR,Address) = '{key}' OR RecepientName = '{key}' OR Convert(VARCHAR,Phone) = '{key}'";
                if (IsInteger)
                {
                    query = $"SELECT * FROM Orders WHERE Id = {Convert.ToInt32(key)}";
                }
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetOrderTable(DateTime date)
        {
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                string query = $"SELECT * FROM Orders WHERE OrderDate = '{date.ToString("MM/dd/yyyy")}'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public static AutoCompleteStringCollection GetAutoCompleteStringCollection(string Query, bool IsInteger = false)
        {
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(Query, cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                if (IsInteger)
                {
                    while (reader.Read())
                        col.Add(reader.GetInt32(0).ToString());
                    return col;
                }
                while (reader.Read())
                    col.Add(reader.GetString(0));
                return col;
            }
        }

        public static int GetInteger(string query)
        {
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                return Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
        }

        public static double GetDouble(string query)
        {
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query, cnn);
                return Convert.ToDouble(cmd.ExecuteScalar().ToString());
            }
        }

        public static string GetString(SqlCommand cmd)
        {
            using (DB.Connect)
            {
                cmd.Connection = DB.Connect;
                return cmd.ExecuteScalar().ToString();
            }
        }

        public static Customer GetCustomer(string key, bool IsInteger = false)
        {
            Customer cust = new Customer();
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                string query = $"SELECT TOP 1 * FROM Customers WHERE FirstName = '{key}' OR LastName = '{key}' OR Phone = '{key}' OR City = '{key}' OR Convert(VARCHAR,Address) = '{key}'";
                if (IsInteger)
                {
                    query = $"SELECT TOP 1 * FROM Customers WHERE Id = {Convert.ToInt32(key)}";
                }
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cust.Id = reader.GetInt32(0);
                    cust.FirstName = reader.GetString(1);
                    cust.LastName = reader.GetString(2);
                    cust.Address = reader.GetString(3);
                    cust.City = reader.GetString(4);
                    cust.State = reader.GetString(5);
                    cust.Phone = reader.GetString(6);
                    cust.DOB = reader.GetString(7);
                    cust.Picture = (byte[])reader.GetSqlBinary(8);
                }
            }

            return cust;
        }

        public static string GetOrderCountByCustomer(int id)
        {
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM Orders WHERE CustomerId = {id}", cnn);
                return cmd.ExecuteScalar().ToString();
            }
        }

        public static List<Order> GetOrderList(Customer c)
        {
            List<Order> li = new List<Order>();

            using (SqlConnection cn = new SqlConnection(DB.ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Orders WHERE CustomerId = {c.Id}", cn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Order o = new Order();
                    o.Id = reader.GetInt32(0);
                    o.CustomerId = reader.GetInt32(1);
                    o.Items = reader.GetString(2);
                    o.RecepientName = reader.GetString(3);
                    o.Address = reader.GetString(4);
                    o.Phone = reader.GetString(5);
                    o.Picture = (byte[])reader.GetSqlBinary(6);
                    o.OrderDate = reader.GetDateTime(7);
                    o.AmountPaid = Convert.ToDouble((decimal)reader.GetSqlMoney(8));
                    li.Add(o);
                }
            }

            return li;
        }

        public static Login GetLogin(string name)
        {
            Login log = new Login();
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                log.Username = name;
                SqlCommand cmd = new SqlCommand($"SELECT Password FROM Login WHERE Username = '{name}'", cnn)
                {
                    CommandType = CommandType.Text
                };
                log.Password = cmd.ExecuteScalar().ToString();
                cmd.CommandText = $"SELECT Id FROM Login WHERE Username = '{name}'";
                log.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return log;
        }

        // Setters

        public static void InsertCustomer(Customer c)
        {
            using (IDbConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                DapperPlusManager.Entity<Customer>().Table("Customers");
                if (c != null)
                {
                    using (IDbConnection connection = new SqlConnection(DB.ConnectionString))
                    {
                        connection.BulkInsert(c);
                    }
                }
            }
        }

        public static void UpdateCustomer(Customer c)
        {
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM Customers WHERE Id = {c.Id};", cnn);
                cmd.ExecuteNonQuery();
            }
            using (IDbConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                DapperPlusManager.Entity<Customer>().Table("Customers");
                if (c != null)
                {
                    using (IDbConnection connection = new SqlConnection(DB.ConnectionString))
                    {
                        connection.BulkInsert(c);
                    }
                }
            }
        }

        public static void DeleteCustomer(Customer c)
        {
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand($"DELETE FROM Customers WHERE Id = {c.Id};", cnn);
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertOrder(Order c)
        {
            using (IDbConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                DapperPlusManager.Entity<Order>().Table("Orders");
                if (c != null)
                {
                    using (IDbConnection connection = new SqlConnection(DB.ConnectionString))
                    {
                        connection.BulkInsert(c);
                    }
                }
            }
        }

        public static void InsertUser(string username, string pass)
        {
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO Login(Username, Password) VALUES ('{username}', '{pass}')", cnn);
                cmd.ExecuteNonQuery();
            }
        }

        public static void ChangePassword(string username, string pass)
        {
            using (SqlConnection cnn = new SqlConnection(DB.ConnectionString))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE Login SET Password = '{pass}' WHERE Username = '{username}'", cnn);
                cmd.ExecuteNonQuery();
            }
        }

        // General

        public static byte[] ConvertImageToBytes(Image img)
        {
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(img);
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            return arr;
        }

        public static Image ConvertBytesToImage(byte[] arr)
        {
            using (MemoryStream ms = new MemoryStream(arr))
            {
                return Bitmap.FromStream(ms);
            }
        }

        public static void ExecuteProcedure(SqlCommand cmd)
        {
            using (DB.Connect)
            {
                cmd.Connection = DB.Connect;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
