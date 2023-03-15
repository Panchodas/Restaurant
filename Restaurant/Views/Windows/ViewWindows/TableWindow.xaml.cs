using Restaurant.Models;
using Restaurant.Views.Windows.AuxiliaryWindows;
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
    /// Логика взаимодействия для TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        public TableWindow()
        {
            InitializeComponent();
            NotReservedTableDg.ItemsSource = App.context.Tables.Where(i => i.IsReserved == false).ToList();
            ReservedTableDg.ItemsSource = App.context.Tables.Where(i => i.IsReserved == true).ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NaviWindow naviWindow = new NaviWindow();
            naviWindow.Show();
            Close();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            NotReservedTableDg.ItemsSource = App.context.Tables.Where(i => i.IsReserved == false).ToList();
            ReservedTableDg.ItemsSource = App.context.Tables.Where(i => i.IsReserved == true).ToList();
            //SearchTb.Text = "";
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridRow_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            if (App.context.Tables.First(i => i.Id == ((Tables)NotReservedTableDg.SelectedItem).Id).IsReserved == false)
            {
                TableActionSelectWindow tableActionSelectWindow = new TableActionSelectWindow(((Tables)NotReservedTableDg.SelectedItem).Id, "NotReservedTableDg");
                tableActionSelectWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Обновите таблицу", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (App.context.Tables.First(i => i.Id == ((Tables)ReservedTableDg.SelectedItem).Id).IsReserved == true)
            {
                TableActionSelectWindow tableActionSelectWindow = new TableActionSelectWindow(((Tables)ReservedTableDg.SelectedItem).Id, "ReservedTableDg");
                tableActionSelectWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Обновите таблицу", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        
    }
}
