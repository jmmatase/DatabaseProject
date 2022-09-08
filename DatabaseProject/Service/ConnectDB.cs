using DatabaseProject.Database;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;

namespace DatabaseProject.Service
{
    
    public class ConnectDB
    {
        public static string serverN = "jm-dabaseserver.database.windows.net";
        private static string pasword = "@117Adm1nP@ss";
        private static string userN = "jmmatase";
        private static string databaseN = "jmdatabase";

        private SqlConnection connectToDB()
        {
            var nn = new SqlConnectionStringBuilder();
            nn.DataSource = serverN;
            nn.UserID = userN;
            nn.Password = pasword;
            nn.InitialCatalog = databaseN;
            return new SqlConnection(nn.ConnectionString);
        }
        public List<DatabaseClass> connectTo()
        {
            List<DatabaseClass> _product_lst = new List<DatabaseClass>();
            string _statement = "SELECT ProductID,ProductName,Quantity from Products";

            SqlConnection _connection = connectToDB();

            _connection.Open();

            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);

            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    DatabaseClass _product = new DatabaseClass()
                    {
                        getID = _reader.GetInt32(0),
                        getName = _reader.GetString(1),
                        getQuintity = _reader.GetInt32(2)
                    };

                    _product_lst.Add(_product);
                }
            }
            _connection.Close();
            return _product_lst;


        }
    }
    
}
