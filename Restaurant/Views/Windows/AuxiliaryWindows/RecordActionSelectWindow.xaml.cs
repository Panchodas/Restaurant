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
    /// Логика взаимодействия для RecordActionSelectWindow.xaml
    /// </summary>
    public partial class RecordActionSelectWindow : Window
    {
        int RecordId;
        int ClientId;
        public RecordActionSelectWindow(int recordId, int clientId)
        {
            InitializeComponent();
            RecordId = recordId;
            ClientId = clientId;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckAddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCheckWindow addCheckWindow = new AddCheckWindow(RecordId, ClientId);
            addCheckWindow.Show();
            Close();
        }
        private void CloseRecordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.context.Records.First(i => i.Id == RecordId).Checks.Count != 0)
            {
                App.context.Records.First(i => i.Id == RecordId).StatusId = 2;
                App.context.SaveChanges();
                MessageBox.Show("Запись успешно закрыта", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Добавьте чек", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
