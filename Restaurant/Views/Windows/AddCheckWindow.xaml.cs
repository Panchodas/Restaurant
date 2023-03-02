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
using System.Windows.Shapes;

namespace Restaurant.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddCheckWindow.xaml
    /// </summary>
    public partial class AddCheckWindow : Window
    {
        public AddCheckWindow()
        {
            InitializeComponent();
            NavigationWindow navigationWindow = new NavigationWindow();
            RecordLbl.Content = ((Models.Records)(navigationWindow.RecordDg.SelectedItem)).Id;
            PaymentMethodCmb.ItemsSource = App.context.PaymentMethods.ToList();
            StatusCmb.ItemsSource = App.context.Statuses.ToList();
        }
    }
}
