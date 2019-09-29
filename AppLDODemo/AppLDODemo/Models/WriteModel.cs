using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppLDODemo.Models.Extensions;
using Repository.Interface.Entities;

namespace AppLDODemo.Models
{
    sealed class WriteModel : NormalModel
    {
        public void CreateDummyData(long recordAmount)
        {
            Random rndm = new Random();

            List<Account> newAccounts = new List<Account>();
            for (int i = 0; i < recordAmount; i++)
            {
                string randomName = rndm.Next(0, 9999999).ToString() + ", " + rndm.Next(0, 9999999).ToString();

                Account newAccount = new Account { id = i, name = randomName };

                newAccounts.Add(newAccount);
            }

            Repository.AddAccounts(newAccounts.ToArray());
        }

        public void DeleteDummyData()
        {
            Repository.DeleteAllAccounts();
        }
    }
}
