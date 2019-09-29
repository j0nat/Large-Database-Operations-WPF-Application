using System.Windows;

using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Windows.Media.Animation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

using System.Xml.Serialization;
using AppLDODemo.ViewModels;


namespace AppLDODemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel viewModel;
        private bool LoadingNotificationPlaying;
        private bool EndLoadingNotificationRequested;

        public MainWindow()
        {
            InitializeComponent();

            this.viewModel = new MainViewModel();
            this.DataContext = viewModel;
            this.LoadingNotificationPlaying = false;
            this.EndLoadingNotificationRequested = false;
        }

        private void FrameLoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (sender.GetType() == typeof(Frame))
            {
                Frame frame = sender as Frame;

                if (frame.Content.GetType().BaseType == typeof(UserControl))
                {
                    UserControl userControl = (UserControl)frame.Content;

                    if (userControl.DataContext != null &&
                        userControl.DataContext.GetType() != typeof(NavigableControlViewModel))
                    {
                        NavigableControlViewModel viewModel = (NavigableControlViewModel)userControl.DataContext;

                        if (viewModel.EventBeginLoadingIsNull)
                        {
                            viewModel.EventBeginLoading += ViewModel_EventBeginLoading;
                        }

                        if (viewModel.EventEndLoadingIsNull)
                        {
                            viewModel.EventEndLoading += ViewModel_EventEndLoading;
                        }
                    }
                }
            }
        }

        private void ViewModel_EventEndLoading(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                this.IsEnabled = true;
            }));

            if (LoadingNotificationPlaying)
            {
                EndLoadingNotificationRequested = true;
            }
            else
            {
                viewModel.IsBusy = false;
            }
        }

        private void ViewModel_EventBeginLoading(string mainLoadMessage, string subLoadMessage)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                UserControl Loading = LoadingFrame.Content as UserControl;

                ((Views.ViewLoading)Loading).MainLoadMessage.Content = mainLoadMessage;
                ((Views.ViewLoading)Loading).SubLoadMessage.Content = subLoadMessage;

                this.IsEnabled = false;
            }));

            viewModel.IsBusy = true;
            LoadingNotificationPlaying = true;
        }

        private void ShowLoadingNotification_Completed(object sender, EventArgs e)
        {
            if (EndLoadingNotificationRequested)
            {
                viewModel.IsBusy = false;

                EndLoadingNotificationRequested = false;
            }

            LoadingNotificationPlaying = false;
        }
    }
}
