using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class ComentarioModel
    {

        private int idComentario;

        public int IdComentario
        {
            get { return idComentario; }
            set { idComentario = value; }
        }

        private string mensagem;

        public string Mensagem
        {
            get { return mensagem; }
            set { mensagem = value; }
        }

        public ComentarioModel(int idComentario, string mensagem)
        {
            IdComentario = idComentario;
            Mensagem = mensagem;
        }

        public ComentarioModel()
        {

        }
    }
}
