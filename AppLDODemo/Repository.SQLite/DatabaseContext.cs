using Repository.Interface.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace Repository.SQLite
{
    class DatabaseContext
    {
        public static DbConnection GetConnection()
        {
            SQLiteConnection connection =
                 new SQLiteConnection(ConfigurationManager.AppSettings["SQLiteConnectionString"].ToString());

            return connection;
        }
    }
}
