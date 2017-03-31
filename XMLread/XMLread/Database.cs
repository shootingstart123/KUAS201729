using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLread
{
    class Database
    {
        private const string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\KUAS201729\XMLread\XMLread\data\data.mdf;Integrated Security=True";


        public void CreateLibrary(XMLread.library li)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO      library(name, address, openTime, phone, fax)
VALUES          (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')
", li.name, li.address, li.openTime, li.phone, li.fax);

            command.ExecuteNonQuery();


            connection.Close();
        }

        public List<XMLread.library> ReadLibrary()
        {
            var result = new List<XMLread.library>();

            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
Select  * from Library ");
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                XMLread.library item = new XMLread.library();
                item.name = reader["name"].ToString();
                item.address = reader["address"].ToString();
                item.openTime = reader["openTime"].ToString();
                item.phone = reader["phone"].ToString();
                item.fax = reader["fax"].ToString();


                result.Add(item);
            }

            //command.ExecuteNonQuery();
            connection.Close();
            return result;
        }
    }
}
