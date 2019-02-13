using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class CapituloModel
    {
        private string idCapitulo;

        public string IdCapitulo
        {
            get { return idCapitulo; }
            set { idCapitulo = value; }
        }

        private string texto;

        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        private string tituloCapitulo;

        public string TituloCapitulo
        {
            get { return tituloCapitulo; }
            set { tituloCapitulo = value; }
        }

        private string dataPostagem;

        public string DataPostagem
        {
            get { return dataPostagem; }
            set { dataPostagem = value; }
        }

        public CapituloModel(string idCapitulo, string texto, string tituloCapitulo, string dataPostagem)
        {
            IdCapitulo = idCapitulo;
            Texto = texto;
            TituloCapitulo = tituloCapitulo;
            DataPostagem = dataPostagem;
        }

        public CapituloModel()
        {

        }
    }
}
