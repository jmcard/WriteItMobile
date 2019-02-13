using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class PerfilModel
    {
        private string idPerfil;

        public string IdPerfil
        {
            get { return idPerfil; }
            set { idPerfil = value; }
        }


        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private String apelido;

        public String Apelido
        {
            get { return apelido; }
            set { apelido = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        private string dataNascimento;

        public string DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        public PerfilModel(string idPerfil, string nome, string apelido, string email, string senha, string nascimento)
        {
            IdPerfil = idPerfil;
            Nome = nome;
            Apelido = apelido;
            Email = email;
            Senha = senha;
            DataNascimento = nascimento;
        }

        public PerfilModel()
        {

        }
    }
}
