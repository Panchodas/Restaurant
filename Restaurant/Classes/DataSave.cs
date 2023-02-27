using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Classes
{
    public class DataSave
    {
        public string Login;
        public string Password;
        public DataSave(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
