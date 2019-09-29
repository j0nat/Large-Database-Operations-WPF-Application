using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppLDODemo.Models.Extensions;
using Repository.Interface.Entities;

namespace AppLDODemo.Models
{
    sealed class ReadModel : NormalModel
    {
        public List<Account> GetAllAccounts()
        {
            return (List<Account>)Repository.GetAccounts();
        }
    }
}
