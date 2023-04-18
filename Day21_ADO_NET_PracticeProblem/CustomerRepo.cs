using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21_ADO_NET_PracticeProblem
{
    public class CustomerRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Day21_ADOdotNET;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void AddCustomer(Customer model)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("spAddCustomer", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@Name", model.Name);
            cmd.Parameters.AddWithValue("@City", model.City);
            cmd.Parameters.AddWithValue("@Address", model.Address);
            cmd.Parameters.AddWithValue("@Phone", model.Phone);
            cmd.Parameters.AddWithValue("@Salary", model.Salary);

            int num = cmd.ExecuteNonQuery();
            if (num != 0)
            {
                Console.WriteLine("Customer added Successfully");
            }
            else
            {
                Console.WriteLine("Something went Wrong");
            }
        }

        public static void GetAllCustomer()
        {
            Customer customer = new Customer();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "select * from Customer";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    customer.Id = Convert.ToInt32(reader["Id"] == DBNull.Value ? default : reader["Id"]);
                    customer.Name = (reader["Name"] == DBNull.Value ? default : reader["Name"]).ToString();
                    customer.City = (reader["City"] == DBNull.Value ? default : reader["City"]).ToString();
                    customer.Address = (reader["Address"] == DBNull.Value ? default : reader["Address"]).ToString();
                    customer.Phone = (int)Convert.ToInt64(reader["MobileNumber"] == DBNull.Value ? default : reader["MobileNumber"]);
                    customer.Salary = (int)Convert.ToInt64(reader["Salary"] == DBNull.Value ? default : reader["Salary"]);

                    Console.WriteLine(customer.Id + "\n" + customer.Name + "\n" + customer.City + "\n" + customer.Address + "\n" + customer.Phone + "\n" + customer.Salary);
                }
            }
        }

        public static void DeleteCustomer(Customer model)
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("spDeleteCustomer", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@Name", model.Name);
            int num = cmd.ExecuteNonQuery();
            if (num != 0)
            {
                Console.WriteLine("Customer Delete Successfully");
            }
            else
            {
                Console.WriteLine("Something went Wrong in Delete Customer");
            }
        }

        public static void UpdateCustomer(Customer model)
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("spUpdateSalary", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            cmd.Parameters.AddWithValue("@Name", model.Name);
            cmd.Parameters.AddWithValue("@Salary", model.Salary);

            int num = cmd.ExecuteNonQuery();
            if (num != 0)
            {
                Console.WriteLine("Customer Update Successfully");
            }
            else
            {
                Console.WriteLine("Something went Wrong in Update Customer");
            }
        }
    }
}
