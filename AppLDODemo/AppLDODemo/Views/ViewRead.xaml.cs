using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using AppLDODemo.ViewModels;

namespace AppLDODemo.Views
{
    /// <summary>
    /// Interaction logic for UserControl2.xaml
    /// </summary>
    public partial class ViewRead : UserControl
    {
        private static ReadViewModel ViewModel = new ReadViewModel();

        public ViewRead()
        {
            InitializeComponent();

            this.DataContext = ViewModel;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.ViewLoaded();
        }
    }
}
