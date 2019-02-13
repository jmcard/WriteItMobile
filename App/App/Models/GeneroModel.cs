using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class GeneroModel
    {

        private int idGenero;

        public int IdGenero
        {
            get { return idGenero; }
            set { idGenero = value; }
        }

        private string nomeGenero;

        public string NomeGenero
        {
            get { return nomeGenero; }
            set { nomeGenero = value; }
        }

        public GeneroModel(int idGenero, string nomeGenero)
        {
            IdGenero = idGenero;
            NomeGenero = nomeGenero;
        }

        public GeneroModel()
        {

        }
    }
}
