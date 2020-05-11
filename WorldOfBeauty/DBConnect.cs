using System.Data.SqlClient;

namespace WorldOfBeauty
{
    class DBConnect
    {
        public static string pc = "localhost";
        public static string cat = "Salon";
        public static string ui = "sa";
        public static string Pass = "123";
        public static SqlConnection sql = new SqlConnection("Data Source = " + pc + "; Initial Catalog = " + cat + ";" +
             "Persist Security Info = true; User ID = " + ui + "; Password = \"" + Pass + "\""); //строка подключения
    }
}