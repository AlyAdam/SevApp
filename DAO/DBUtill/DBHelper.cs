using System.Data.SqlClient;

namespace SevStudentsApp.DAO.DBUtill
{
    public class DBHelper
    {
        private static SqlConnection? conn;

        private DBHelper() { }

        public static SqlConnection? getConnection()
        {
            try
            {
                ConfigurationManager configurationManager = new();
                configurationManager.AddJsonFile("appsettings.json");
                string url = configurationManager.GetConnectionString("DefaultConnection");
               conn = new SqlConnection(url);
               return conn;
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
        public static void CloseConnection()
        {
            if (conn is not null)
            {
                conn.Close();
            }
        }
    }
}
