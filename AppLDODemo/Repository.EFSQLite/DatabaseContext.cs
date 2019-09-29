using Repository.Interface.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace Repository.EFSQLite
{
    [DbConfigurationType(typeof(DatabaseConfiguration))]
    class DatabaseContext : DbContext
    {
        public IDbSet<Account> Accounts { get; set; }

        public DatabaseContext() : base(GetConnection(), false)
        {

        }

        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = 
                 new SQLiteConnection(ConfigurationManager.AppSettings["SQLiteConnectionString"].ToString());

            return connection;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
