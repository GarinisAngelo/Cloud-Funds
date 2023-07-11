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
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection...");
            //Your Connection string here
            string connString = @"Data Source=(local); Initial Catalog=FundRaiser-2023; Integrated security=true; TrustServerCertificate=True";
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            ;
        }
    }
}
