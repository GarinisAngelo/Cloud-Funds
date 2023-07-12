using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundRaiserProject2023.Services
{
    public class ConnectToDB
    {
        public void Connect()
        {
            Console.WriteLine("Getting Connection...");
            //Your Connection string here
            string connectionString = "Data Source=(local); Initial Catalog=MyTestFundRaiserDB; Integrated security=true; TrustServerCertificate=True";
            using var connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            //local query example
            string query = "SELECT Name FROM Users JOIN Backers ON Users.Id = Backers.Id JOIN Projects ON Backers.ProjectId = Projects.Id WHERE Title = 'Title1'";
            using var command = new SqlCommand(query, connection);            
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Name: {reader.GetString(0)}");
            }
        }
    }
}
