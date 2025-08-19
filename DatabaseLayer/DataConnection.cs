
using System.Configuration;


namespace DatabaseLayer
{
    public class DataConnection
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["LIMSConnection"].ConnectionString; }
        }
    }
}
