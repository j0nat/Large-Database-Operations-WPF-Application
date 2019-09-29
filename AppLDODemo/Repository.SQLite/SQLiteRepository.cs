using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Repository.Interface;
using Repository.Interface.Entities;

using System.Data.SQLite;

namespace Repository.SQLite
{
    // EntityFramework for SQLite does not support automatic table creation / update.

    public class SQLiteRepository : IAccountRepository
    {
        public IEnumerable<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();

            SQLiteConnection connection = (SQLiteConnection)DatabaseContext.GetConnection();
            connection.Open();

            SQLiteCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM account";

            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                accounts.Add(new Account { 
                    id = Convert.ToInt64(reader["id"]),
                    name = reader["name"].ToString()
                });
            }

            connection.Close();

            return accounts;
        }

        public Account GetAccount(string id)
        {
            throw new NotImplementedException();
        }

        public void AddAccount(Account newAccount)
        {
            SQLiteConnection connection = (SQLiteConnection)DatabaseContext.GetConnection();
            connection.Open();

            SQLiteCommand command = connection.CreateCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO account VALUES(@0, @1)";

            command.Parameters.Add(new SQLiteParameter("@0", newAccount.id));
            command.Parameters.Add(new SQLiteParameter("@1", newAccount.name));

            command.ExecuteNonQuery();
            connection.Close();
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
            SQLiteConnection connection = (SQLiteConnection)DatabaseContext.GetConnection();
            connection.Open();

            SQLiteCommand command = connection.CreateCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = "DELETE FROM account";

            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateAccounts(IEnumerable<Account> updatedAccounts)
        {
            throw new NotImplementedException();
        }

        public void AddAccounts(IEnumerable<Account> newAccounts)
        {
            Account[] accounts = newAccounts.ToArray();

            SQLiteConnection connection = (SQLiteConnection)DatabaseContext.GetConnection();
            connection.Open();

            using (SQLiteTransaction transaction = connection.BeginTransaction())
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO account VALUES(null, @0)";

                    SQLiteParameter paramName = new SQLiteParameter("@0");
                    command.Parameters.Add(paramName);

                    for (int i = 0; i < accounts.Length; i++)
                    {
                        paramName.Value = accounts[i].name;

                        command.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
            }
        }
    }
}