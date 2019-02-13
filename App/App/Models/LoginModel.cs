using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class LoginModel
    {

        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public LoginModel(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }

        public LoginModel()
        {

        }
    }
}
