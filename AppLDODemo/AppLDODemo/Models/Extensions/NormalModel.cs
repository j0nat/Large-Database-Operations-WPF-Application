using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.Interface;
using System.ComponentModel;
using System.Configuration;

namespace AppLDODemo.Models.Extensions
{
    class NormalModel
    {
        public IAccountRepository Repository { get; private set; }

        public NormalModel()
        {
            Repository = RepositoryFactory.GetRepository
                (ConfigurationManager.AppSettings["Repository"].ToString());
        }
    }
}
