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
    /// Логика взаимодействия для AuthentificationWindow.xaml
    /// </summary>
    public partial class AuthentificationWindow : Window
    {
        public AuthentificationWindow()
        {
            InitializeComponent();
        }
        private void Auth()
        {
            if (!(string.IsNullOrEmpty(LoginTb.Text) || string.IsNullOrEmpty(PasswordPb.Password)))
            {
                if (App.context.Admins.FirstOrDefault(i => i.Login == LoginTb.Text && i.Password == PasswordPb.Password) != null)
                {
                    MessageBox.Show("Вы вошли", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    NaviWindow naviWindow = new NaviWindow();
                    naviWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Auth();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Close();
        }
        private void PasswordRecoveryBtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordRecoveryWindow passwordRecoveryWindow = new PasswordRecoveryWindow();
            passwordRecoveryWindow.Show();
            Close();
        }
    }
}
