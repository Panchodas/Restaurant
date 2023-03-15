using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddRecordWindow.xaml
    /// </summary>
    public partial class AddRecordWindow : Window
    {
        public AddRecordWindow()
        {
            InitializeComponent();
            TableCmb.ItemsSource = App.context.Tables.Where(i => i.IsReserved == false).ToList();
            ClientCmb.ItemsSource = App.context.Clients.ToList();
        }
        private void AddRecord()
        {
            if (!(string.IsNullOrEmpty(TableCmb.Text)
                || string.IsNullOrEmpty(ClientCmb.Text)
                || string.IsNullOrEmpty(TimeTb.Text)))
            {
                Records records = new Records()
                {
                    ClientId = ((Clients)ClientCmb.SelectedItem).Id,
                    TableId = ((Tables)TableCmb.SelectedItem).Id,
                    VisitTime = TimeSpan.Parse(TimeTb.Text),
                    StatusId = 1
                };
                App.context.Records.Add(records);
                App.context.SaveChanges();
                App.context.Tables.First(i => i.Id == ((Tables)TableCmb.SelectedItem).Id).IsReserved = true;
                App.context.SaveChangesAsync();
                MessageBox.Show("Запись добавлена");
                RecordWindow recordWindow = new RecordWindow();
                recordWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddRecord();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            RecordWindow recordWindow = new RecordWindow();
            recordWindow.Show();
            Close();
        }
    }
}
