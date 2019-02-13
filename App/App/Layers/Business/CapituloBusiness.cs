using App.Layers.Service;
using App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Layers.Business
{
    public class CapituloBusiness
    {

        public void CadastrarCapitulo(CapituloModel Capitulo, String Id)
        {
            new CapituloService().CadastrarCapitulo(Capitulo,Id);
        }

        public String RetornarId()
        {
            _id = Global.HistoriaPosicao.IdHistoria;
            string id = _id;
            return id;
        }

        public IList<Models.CapituloModel> ListarCapitulos()
        {
            _id = Global.HistoriaPosicao.IdHistoria;
            string id = _id;
            return new CapituloService().GetCapitulos(id);
        }

        private String _id;

        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}
