using App.Layers.Service;
using App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Layers.Business
{
    public class PerfilBusiness
    {
        public void CadastroPerfil(Models.PerfilModel perfil)
        {
            new PerfilService().Cadastro(perfil);
        }

        public PerfilModel Login(Models.LoginModel _login)
        {
            PerfilModel _perfil = new PerfilService().Login(_login);
            if (_login.Login.Equals(_perfil.Email) && _login.Senha.Equals(_perfil.Senha))
            {
                return _perfil;
            }
            else
            {
                return new PerfilModel();
            }

        }

        public String RetornarId()
        {
            _email = Global.EmailPerfil;
            string email = _email;
            return new PerfilService().BuscarId(email);
        }
        
        public PerfilModel DadosPerfil()
        {
            _email = Global.EmailPerfil;
            string email = _email;
            return new PerfilService().BuscarDados(email);
        }

        private String _email;

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        

    }
}
