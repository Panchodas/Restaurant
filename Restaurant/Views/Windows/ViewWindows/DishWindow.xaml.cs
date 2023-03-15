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
    /// Логика взаимодействия для DishWindow.xaml
    /// </summary>
    public partial class DishWindow : Window
    {
        public DishWindow()
        {
            InitializeComponent();
            DishDg.ItemsSource = App.context.Dishes.ToList();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.context.Dishes.Where(i => i.DishTypes.Name == SearchTb.Text || i.Name == SearchTb.Text || i.Сomposition == SearchTb.Text).Count() != 0)
            {
                DishDg.ItemsSource = App.context.Clients.Where(i => i.SNM == SearchTb.Text || i.PhoneNumber == SearchTb.Text).ToList();
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            DishDg.ItemsSource = App.context.Dishes.ToList();
            SearchTb.Text = "";
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NaviWindow naviWindow = new NaviWindow();
            naviWindow.Show();
            Close();
        }
    }
}
