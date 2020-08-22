using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Program {
        static void Main(string[] args) {
           // Source = R2D2; Initial Catalog = Northwind; Integrated Security = True; Connect
            string tmp = "Server=R2D2;Database=Northwind;Integrated Security = True";
            SQLConnectionFactory test = new SQLConnectionFactory(tmp);
            
            SqlConnection conn = (SqlConnection) test.CreateConnection();
            SqlCommand cmd = new SqlCommand("SELECT RegionID, RegionDescription from Region", conn);

            var reader = cmd.ExecuteReader();

            while (reader.Read()) {
                Console.WriteLine(reader.GetValue(0) + "|" + reader.GetValue(1));
            }

            conn.Close();

            Console.ReadLine();


        }
    }
}
