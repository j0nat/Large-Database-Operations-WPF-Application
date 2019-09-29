using System;
using System.Collections.Generic;
using System.Linq;
using Repository.Interface;
using Repository.Interface.Entities;

namespace Repository.EFSQLite
{
    // EntityFramework for SQLite does not support automatic table creation / update.

    public class EFSQLiteRepository : IAccountRepository
    {
        public IEnumerable<Account> GetAccounts()
        {
            using (var context = new DatabaseContext())
            {
                return context.Accounts.ToList();
            }
        }

        public Account GetAccount(string id)
        {
            throw new NotImplementedException();
        }

        public void AddAccount(Account newAccount)
        {
            using (var context = new DatabaseContext())
            {
                context.Accounts.Add(newAccount);
                context.SaveChanges();
            }
        }

        public void UpdateAccount(string name, Account updatedAccount)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(string name)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllAccounts()
        {
            throw new NotImplementedException();
        }

        public void UpdateAccounts(IEnumerable<Account> updatedAccounts)
        {
            throw new NotImplementedException();
        }

        public void AddAccounts(IEnumerable<Account> newAccount)
        {
            throw new NotImplementedException();
        }
    }
}
