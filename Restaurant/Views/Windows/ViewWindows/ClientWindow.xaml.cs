﻿using Restaurant.Models;
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

namespace Restaurant.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
            ClientDg.ItemsSource = App.context.Clients.ToList();
        }

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            addClientWindow.Show();
            Close();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.context.Clients.Where(i => i.SNM == SearchTb.Text || i.PhoneNumber == SearchTb.Text).Count() != 0)
            {
                ClientDg.ItemsSource = App.context.Clients.Where(i => i.SNM == SearchTb.Text || i.PhoneNumber == SearchTb.Text).ToList();
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientDg.ItemsSource = App.context.Clients.ToList();
            SearchTb.Text = "";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NaviWindow naviWindow = new NaviWindow();
            naviWindow.Show();
            Close();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить этого клиента?", "",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                App.context.Clients.Remove(App.context.Clients.First(i => i.Id == ((Clients)ClientDg.SelectedItem).Id));
                App.context.SaveChanges();
                MessageBox.Show("Пользователь успешно удалён", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (result == MessageBoxResult.No)
            {
                return;
            }
        }
    }
}
