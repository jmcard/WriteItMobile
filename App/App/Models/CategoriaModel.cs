using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class CategoriaModel
    {
        private string idCategoria;

        public string IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }

        private string nomeCategoria;

        public string NomeCategoria
        {
            get { return nomeCategoria; }
            set { nomeCategoria = value; }
        }

        public CategoriaModel(string idCategoria, string nomeCategoria)
        {
            IdCategoria = idCategoria;
            NomeCategoria = nomeCategoria;
        }

        public CategoriaModel()
        {

        }
    }
}
