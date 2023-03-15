using Restaurant.Views.Windows.ViewWindows;
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
    /// Логика взаимодействия для NaviWindow.xaml
    /// </summary>
    public partial class NaviWindow : Window
    {
        public NaviWindow()
        {
            InitializeComponent();
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow();
            clientWindow.Show();
            Close();
        }

        private void RecordBtn_Click(object sender, RoutedEventArgs e)
        {
            RecordWindow recordWindow = new RecordWindow();
            recordWindow.Show();
            Close();
        }

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckWindow checkWindow = new CheckWindow();
            checkWindow.Show();
            Close();
        }

        private void TableBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DishBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthentificationWindow authentificationWindow = new AuthentificationWindow();
            authentificationWindow.Show();
            Close();
        }
    }
}
