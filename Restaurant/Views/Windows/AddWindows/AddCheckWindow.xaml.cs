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
    /// Логика взаимодействия для AddCheckWindow.xaml
    /// </summary>
    public partial class AddCheckWindow : Window
    {
        public AddCheckWindow(int recordId, int clientId)
        {
            InitializeComponent();
            NaviWindow navigationWindow = new NaviWindow();
            PaymentMethodCmb.ItemsSource = App.context.PaymentMethods.ToList();
            PaymentMethodCmb.Text = App.context.PaymentMethods.First(i => i.Id > -1).Name;
            RecordLbl.Content = App.context.Records.First(i => i.Id == recordId).Id;
            ClientLbl.Content = App.context.Clients.First(i => i.Id == clientId).Id;
            BonusLbl.Content = App.context.Clients.First(i => i.Id == clientId).Bonuses;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!(string.IsNullOrEmpty(GuestBillTb.Text)
                || string.IsNullOrEmpty(PaymentMethodCmb.Text)))
            {
                Checks checks = new Checks()
                {
                    RecordId = (int)RecordLbl.Content,
                    GuestBill = decimal.Parse(GuestBillTb.Text),
                    PaymentMethodId = ((PaymentMethods)PaymentMethodCmb.SelectedItem).Id,
                    BonusesReceived = Convert.ToDecimal(PlusBonusLbl.Content)
                };
                App.context.Checks.Add(checks);
                if (PaymentMethodCmb.Text == "Бонусами")
                {
                    App.context.Clients.First(i => i.Id == (int)ClientLbl.Content).Bonuses = App.context.Clients.First(i => i.Id == (int)ClientLbl.Content).Bonuses - int.Parse(GuestBillTb.Text);
                }
                else
                {
                    App.context.Clients.First(i => i.Id == (int)ClientLbl.Content).Bonuses = App.context.Clients.First(i => i.Id == (int)ClientLbl.Content).Bonuses + (decimal)PlusBonusLbl.Content;
                }
                App.context.SaveChanges();
                MessageBox.Show("Чек добавлен");
                Close();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }
        private void GuestBillTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PaymentMethodCmb.Text != "Бонусами")
            {
                if (!string.IsNullOrEmpty(GuestBillTb.Text))
                {
                    PlusBonusLbl.Content = decimal.Parse(GuestBillTb.Text) / 10;
                }
                else
                {
                    PlusBonusLbl.Content = 0;
                }
            }
            else
            {
                PlusBonusLbl.Content = 0;
            }
        }

        private void PaymentMethodCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PaymentMethodCmb.SelectedIndex == 1)
            {
                PlusBonusLbl.Content = 0;
            }
            else
            {
                if (!string.IsNullOrEmpty(GuestBillTb.Text))
                {
                    PlusBonusLbl.Content = decimal.Parse(GuestBillTb.Text) / 10;
                }
                else
                {
                    PlusBonusLbl.Content = 0;
                }
            }
        }
    }
}
