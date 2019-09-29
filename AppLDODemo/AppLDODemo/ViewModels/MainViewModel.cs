using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using Repository.Interface;
using System.Xml.Serialization;

namespace AppLDODemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
