using Restaurant.Classes;
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
    /// Логика взаимодействия для PasswordRecoveryWindow.xaml
    /// </summary>
    public partial class PasswordRecoveryWindow : Window
    {
        public PasswordRecoveryWindow()
        {
            InitializeComponent();
        }
        public void PasswordRecoveryMethod()
        {
            if (!(string.IsNullOrEmpty(MailTb.Text) || string.IsNullOrEmpty(PasswordPb.Password) || string.IsNullOrEmpty(RepeatedNewPasswordPb.Password)))
            {
                var logPass = App.context.Admins.FirstOrDefault(i => i.Login == MailTb.Text && i.Password == PasswordPb.Password);
                if (logPass != null)
                {
                    if (PasswordPb.Password != NewPasswordPb.Password)
                    {
                        App.context.Admins.First(i => i.Login == MailTb.Text && i.Password == PasswordPb.Password).Password = NewPasswordPb.Password;
                        App.context.SaveChanges();
                        MessageBox.Show("Пароль изменён");
                        AuthentificationWindow authentification = new AuthentificationWindow();
                        authentification.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Не используйте старый пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }
        private bool PasswordCheck(bool resp)
        {
            if (NewPasswordPb.Password == RepeatedNewPasswordPb.Password)
            {
                resp = true;
            }
            else
            {
                MessageBox.Show("Пароли должны совпадать");
            }
            return resp;
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthentificationWindow authentificationWindow = new AuthentificationWindow();
            authentificationWindow.Show();
            Close();
        }

        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            bool resp = false;
            resp = PasswordCheck(resp);
            if (resp == true)
            {
                PasswordRecoveryMethod();
            }
        }
    }
}
