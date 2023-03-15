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

namespace Restaurant.Views.Windows.AuxiliaryWindows
{
    /// <summary>
    /// Логика взаимодействия для TableActionSelectWindow.xaml
    /// </summary>
    public partial class TableActionSelectWindow : Window
    {
        private readonly int tableIdValue;
        private readonly string motherGridValue;
        public TableActionSelectWindow(int tableId, string motherGrid)
        {
            InitializeComponent();
            tableIdValue = tableId;
            motherGridValue = motherGrid;
            if (motherGrid == "ReservedTableDg")
            {
                DereserveTableBtn.Content = "Сделать столик свободным";
                return;
            }
            if (motherGrid == "NotReservedTableDg")
            {
                DereserveTableBtn.Content = "Зарезервировать столик";
                return;
            }
        }

        private void DereserveTableBtn_Click(object sender, RoutedEventArgs e)
        {
            if (motherGridValue == "ReservedTableDg")
            {
                App.context.Tables.First(i => i.Id == tableIdValue).IsReserved = false;
                App.context.SaveChangesAsync();
                MessageBox.Show("Столик успешно освобождён", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                return;
            }
            if (motherGridValue == "NotReservedTableDg")
            {
                App.context.Tables.First(i => i.Id == tableIdValue).IsReserved = true;
                App.context.SaveChangesAsync();
                MessageBox.Show("Столик успешно зарезервирован", "", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                return;
            }
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
