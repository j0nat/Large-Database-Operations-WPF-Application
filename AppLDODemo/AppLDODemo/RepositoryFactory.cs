using Repository.Interface;
using Repository.SQLite;
using System;

namespace AppLDODemo
{
    class RepositoryFactory
    {
        public static IAccountRepository GetRepository(string repositoryType)
        {
            IAccountRepository repo = null;
            switch (repositoryType)
            {
                case "SQLite":
                    repo = new SQLiteRepository();
                    break;
                default:
                    throw new ArgumentException("Invalid Repository Type");
            }
            return repo;
        }
    }
}
