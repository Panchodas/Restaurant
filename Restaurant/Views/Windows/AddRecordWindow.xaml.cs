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
            TableCmb.ItemsSource = App.context.Tables.Where(i => i.IsReserved == true).ToList();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow navigationWindow = new NavigationWindow();
            navigationWindow.Show();
            Close();
        }
        private void AddRecord()
        {
            if (!(string.IsNullOrEmpty(TableCmb.Text)
                || string.IsNullOrEmpty(ClientCmb.Text)
                || string.IsNullOrEmpty(TimeTb.Text)))
            {
                //Добавление записи
                Records records = new Records()
                {
                    ClientId = int.Parse(ClientCmb.Text),
                    TableId = int.Parse(TableCmb.Text),
                    VisitTime = TimeSpan.Parse(TimeTb.Text)
                };
                App.context.Records.Add(records);
                App.context.SaveChanges();

                //Сохранение Id
                var tableId = App.context.Tables.Find(App.context.Tables.Where(i => i.Number == int.Parse(TableCmb.Text)).FirstOrDefault()).Id;

                //Удаление стола
                var table = App.context.Tables.Where(i => i.Number == int.Parse(TableCmb.Text)).FirstOrDefault();
                App.context.Tables.Remove(table);
                App.context.SaveChanges();

                //Добавление стола
                Tables tables = new Tables()
                {
                    Id = tableId,
                    Number = int.Parse(TableCmb.Text),
                    IsReserved = true
                };
                App.context.SaveChanges();
                MessageBox.Show("Запись добавлена");
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
    }
}
