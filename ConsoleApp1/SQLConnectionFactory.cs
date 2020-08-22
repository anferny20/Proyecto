using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class SQLConnectionFactory : IDbConnectionFactory {

        private string connectionString;

        public SQLConnectionFactory(string tmpConnection) {

            connectionString = tmpConnection;

        }

        public IDbConnection CreateConnection() {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;

        }

    }
}
