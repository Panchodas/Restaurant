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
    /// Логика взаимодействия для CheckWindow.xaml
    /// </summary>
    public partial class CheckWindow : Window
    {
        private string checkWindowMotherWindow;
        public CheckWindow(string motherWindow)
        {
            InitializeComponent();
            CheckDg.ItemsSource = App.context.Checks.ToList();
            checkWindowMotherWindow = motherWindow;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            //if (App.context.Checks.Where(i => i.PaymentMethodId == SearchTb.Text).Count() != 0)
            //{
            //    ClientDg.ItemsSource = App.context.Checks.Where(i => i.PaymentMethodId == SearchTb.Text).ToList();
            //}
        }

        private void PrintCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckDg.SelectedItem != null)
            {
                MessageBox.Show("Чек напечатан", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите чек", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if(checkWindowMotherWindow == "NaviWindow")
            {
                NaviWindow naviWindow = new NaviWindow();
                naviWindow.Show();
                Close();
            }
            else
            {
                RecordWindow recordWindow = new RecordWindow();
                recordWindow.Show();
                Close();
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckDg.ItemsSource = App.context.Checks.ToList();
            SearchTb.Text = "";
        }
    }
}
