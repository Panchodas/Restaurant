using Restaurant.Views.Windows.AddWindows;
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

namespace Restaurant.Views.Windows.ViewWindows
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();
            OrderDg.ItemsSource = App.context.Orders.ToList();
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow();
            addOrderWindow.Show();
            Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NaviWindow naviWindow = new NaviWindow();
            naviWindow.Show();
            Close();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderDg.ItemsSource = App.context.Orders.ToList();
            SearchTb.Text = "";
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.context.Orders.Where(i => i.Clients.SNM == SearchTb.Text || i.Dishes.Name == SearchTb.Text).Count() != 0)
            {
                OrderDg.ItemsSource = App.context.Orders.Where(i => i.Clients.SNM == SearchTb.Text || i.Dishes.Name == SearchTb.Text).ToList();
            }
        }
    }
}
