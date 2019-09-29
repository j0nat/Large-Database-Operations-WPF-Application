using System;
using System.Collections.Generic;
using System.Windows.Input;
using AppLDODemo.ExtensionMethods;
using System.Threading;
using Repository.Interface.Entities;
using System.Windows;
using AppLDODemo.Models;

namespace AppLDODemo.ViewModels
{
    class WriteViewModel : NavigableControlViewModel
    {
        private WriteModel writeModel { get; set; }
        public ICommand GenerateDummyDataCommand { get; set; }
        public ICommand DeleteDummyDataCommand { get; set; }

        public WriteViewModel()
        {
            writeModel = new WriteModel();
            GenerateDummyDataCommand = new RelayCommand(o => GenerateDummyDataClick("GenerateDummyDataCommandButton"));
            DeleteDummyDataCommand = new RelayCommand(o => DeleteDummyDataClick("DeleteDummyDataCommandButton"));

            SetStatusUpdate("Ready.");
            RecordAmountValue = "1234567";
        }

        private string _recordAmountValue;
        public string RecordAmountValue
        {
            get { return _recordAmountValue; }
            set
            {
                _recordAmountValue = value;
                RaisePropertyChanged("RecordAmountValue");
            }
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

        private void SetStatusUpdate(string status)
        {
            StatusUpdate = "STATUS: " + status;
        }

        private void GenerateDummyDataClick(object sender)
        {
            if (StringExtensions.IsNumeric(RecordAmountValue))
            {
                long records = Convert.ToInt64(RecordAmountValue);

                Thread thread = new Thread(() => GenerateDummyData(records));
                thread.IsBackground = true; // Terminate process if main thread exits
                thread.Priority = ThreadPriority.Highest;
                thread.Start();
            }
        }

        private void DeleteDummyDataClick(object sender)
        {
            Thread thread = new Thread(() => DeleteDummyData());
            thread.IsBackground = true; // Terminate process if main thread exits
            thread.Priority = ThreadPriority.Highest;
            thread.Start();
        }

        private void GenerateDummyData(long recordAmount)
        {
            SetStatusUpdate("Making dummy data...");
            BeginLoading("Making Dummy Data", "Creating and storing " + recordAmount + " records in database.");

            SetStatusUpdate("Generating dummy data...");

            writeModel.CreateDummyData(recordAmount);

            EndLoading();
            SetStatusUpdate("Finished adding dummy data to database.");
        }

        private void DeleteDummyData()
        {
            SetStatusUpdate("Started deleting dummy data...");

            MessageBoxResult msg = MessageBox.Show("Are you sure you want to delete all dummy data?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (msg == MessageBoxResult.Yes)
            {
                writeModel.DeleteDummyData();

                MessageBox.Show("Dummy data deleted.");
            }

            SetStatusUpdate("Finished deleting dummy data.");
        }
    }
}