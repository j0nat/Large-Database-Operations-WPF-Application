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
using System.Text.RegularExpressions;

namespace AppLDODemo.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ViewWrite : UserControl
    {
        private static WriteViewModel ViewModel = new WriteViewModel();

        public ViewWrite()
        {
            InitializeComponent();

            this.DataContext = ViewModel;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxRecordAmountValue.Focus();
            TextBoxRecordAmountValue.SelectAll();
        }
    }
}
