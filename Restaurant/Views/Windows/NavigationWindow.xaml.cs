﻿using Restaurant.Models;
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
    /// Логика взаимодействия для NavigationWindow.xaml
    /// </summary>
    public partial class NavigationWindow : Window
    {
        public NavigationWindow()
        {
            InitializeComponent();
            RecordDg.ItemsSource = App.context.Records.ToList();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthentificationWindow authentificationWindow = new AuthentificationWindow();
            authentificationWindow.Show();
            Close();
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(((Records)RecordDg.SelectedItem).StatusId != 2)
            {
                RecordActionSelectWindow recordActionSelectWindow = new RecordActionSelectWindow(((Records)RecordDg.SelectedItem).Id, ((Records)RecordDg.SelectedItem).Clients.Id);
                recordActionSelectWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Эта запись уже закрыта");
            }
        }
        private void AddRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            AddRecordWindow addRecordWindow = new AddRecordWindow();
            addRecordWindow.Show();
            Close();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            RecordDg.ItemsSource = App.context.Records
                .Where(i => i.Clients.SNM == SearchTb.Text || i.Tables.Number == SearchTb.Text || i.Statuses.Name == SearchTb.Text).ToList();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            RecordDg.ItemsSource = App.context.Records.ToList();
        }

        private void SeeCheckBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
