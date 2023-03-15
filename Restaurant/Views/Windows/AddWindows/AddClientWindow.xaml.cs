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

namespace Restaurant.Views.Windows.AddWindows
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow();
            clientWindow.Show();
            Close();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(SNMTb.Text)
                || string.IsNullOrEmpty(PhoneNumberTb.Text)))
            {
                Clients clients = new Clients()
                {
                    SNM = SNMTb.Text,
                    Bonuses = 0,
                    PhoneNumber = PhoneNumberTb.Text
                };
                App.context.Clients.Add(clients);
                App.context.SaveChanges();
                MessageBox.Show("Клиент добавлен");
                ClientWindow clientWindow = new ClientWindow();
                clientWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }
    }
}
