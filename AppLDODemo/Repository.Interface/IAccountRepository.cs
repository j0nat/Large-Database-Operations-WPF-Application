using System.Collections.Generic;
using Repository.Interface.Entities;

namespace Repository.Interface
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();

        Account GetAccount(string name);

        void AddAccount(Account newAccount);

        void AddAccounts(IEnumerable<Account> newAccount);

        void UpdateAccount(string name, Account updatedAccount);

        void DeleteAccount(string name);

        void DeleteAllAccounts();

        void UpdateAccounts(IEnumerable<Account> updatedAccounts);
    }
}
