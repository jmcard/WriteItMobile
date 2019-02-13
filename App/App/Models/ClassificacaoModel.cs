using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class ClassificacaoModel
    {
        private string idClassif;

        public string IdClassif
        {
            get { return idClassif; }
            set { idClassif = value; }
        }

        private string nomeClassif;

        public string NomeClassif
        {
            get { return nomeClassif; }
            set { nomeClassif = value; }
        }

        private string descricao;

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public ClassificacaoModel(string idClassif, string nomeClassif, string descricao)
        {
            IdClassif = idClassif;
            NomeClassif = nomeClassif;
            Descricao = descricao;
        }

        public ClassificacaoModel()
        {

        }
    }
}
