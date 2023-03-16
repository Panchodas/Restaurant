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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private void Registaration()
        {
            if (!(string.IsNullOrEmpty(MailTb.Text) || string.IsNullOrEmpty(PasswordPb.Password) || string.IsNullOrEmpty(RepeatedPasswordPb.Password)))
            {
                //if (PasswordPb.Password == RepeatedPasswordPb.Password)
                //{

                //}
                //if ()
                //{
                //    MessageBox.Show("Вы успешно зарегистрированы");
                //    AuthentificationWindow authentificationWindow = new AuthentificationWindow();
                //    authentificationWindow.Show();
                //    Close();
                //}
                //switch ()
                //{

                //}
                var logPass = App.context.Admins.FirstOrDefault(i => i.Login == MailTb.Text);
                if (logPass != null)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                }
                else
                {
                    bool resp = false;
                    resp = PasswordCheck(resp);
                    if (resp == true)
                    {
                        AddUser();
                        AuthentificationWindow authentification = new AuthentificationWindow();
                        authentification.Show();
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                //MessageBox.Show("Неверный логин или пароль");
            }
        }
        private bool PasswordCheck(bool resp)
        {
            if (PasswordPb.Password == RepeatedPasswordPb.Password)
            {
                resp = true;
            }
            else
            {
                MessageBox.Show("Пароли должны совпадать", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return resp;
        }
        private void AddUser()
        {
            Admins admins = new Admins()
            {
                Login = MailTb.Text,
                Password = RepeatedPasswordPb.Password
            };
            App.context.Admins.Add(admins);
            App.context.SaveChanges();
            MessageBox.Show("Вы успешно зарегистрированы", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthentificationWindow authentificationWindow = new AuthentificationWindow();
            authentificationWindow.Show();
            Close();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            Registaration();
        }
    }
}
