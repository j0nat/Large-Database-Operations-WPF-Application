using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Configuration;
using Repository.Interface;

namespace AppLDODemo.ViewModels
{
    public class NavigableControlViewModel : INotifyPropertyChanged
    {
        public delegate void LoadingEventHandler(string loadHead, string loadSubHead);
        public event LoadingEventHandler EventBeginLoading;
        public event EventHandler EventEndLoading;

        public bool EventBeginLoadingIsNull
        {
            get
            {
                if (EventBeginLoading == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool EventEndLoadingIsNull
        {
            get
            {
                if (EventEndLoading == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void BeginLoading(string loadHead, string loadSubHead)
        {
            EventBeginLoading(loadHead, loadSubHead);
        }

        public void EndLoading()
        {
            EventEndLoading(this, new EventArgs());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
