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
            //RecordDg.SelectedItem
            //IdColumn.
        }
    }
}
