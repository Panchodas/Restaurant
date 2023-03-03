using Restaurant.Classes;
using Restaurant.Models;
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
        public AddCheckWindow(int clientId)
        {
            InitializeComponent();
            NavigationWindow navigationWindow = new NavigationWindow();
            PaymentMethodCmb.ItemsSource = App.context.PaymentMethods.ToList();
            StatusCmb.ItemsSource = App.context.Statuses.ToList();
            PaymentMethodCmb.Text = App.context.PaymentMethods.First(i => i.Id > -1).Name;
            StatusCmb.Text = App.context.Statuses.First(i => i.Id > -1).Name;
            BonusLbl.Content = App.context.Clients.First(i => i.Id == clientId).Bonuses;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow navigationWindow = new NavigationWindow();
            navigationWindow.Show();
            Close();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
