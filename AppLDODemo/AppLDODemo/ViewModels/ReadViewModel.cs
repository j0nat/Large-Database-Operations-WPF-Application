using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using Repository.Interface;
using System.Xml.Serialization;
using Repository.Interface.Entities;
using System.Threading;
using AppLDODemo.Models;

namespace AppLDODemo.ViewModels
{
    public class ReadViewModel : NavigableControlViewModel
    {
        private ReadModel readModel { get; set; }

        public ReadViewModel()
        {
            readModel = new ReadModel();
        }

        private string _statusUpdate;
        public string StatusUpdate
        {
            get { return _statusUpdate; }
            set
            {
                _statusUpdate = value;
                RaisePropertyChanged("StatusUpdate");
            }
        }

        private List<Account> _accountList;
        public List<Account> AccountList
        {
            get { return _accountList; }
            set
            {
                _accountList = value;
                RaisePropertyChanged("AccountList");
            }
        }

        public void ViewLoaded()
        {
            SetStatus("Loading records...");

            Thread thread = new Thread(() => UpdateAccountList());
            thread.IsBackground = true; // Terminate process if main thread exits
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
        }

        public void UpdateAccountList()
        {
            AccountList = readModel.GetAllAccounts();

            SetRecordAmount(AccountList.Count.ToString());
        }

        private void SetRecordAmount(string numRecords)
        {
            StatusUpdate = numRecords + " Records loaded.";
        }

        private void SetStatus(string status)
        {
            StatusUpdate = status;
        }
    }
}
