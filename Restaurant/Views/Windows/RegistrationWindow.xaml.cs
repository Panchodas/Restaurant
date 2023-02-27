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
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
                //MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthentificationWindow authentificationWindow = new AuthentificationWindow();
            authentificationWindow.Show();
            Close();
        }
    }
}
