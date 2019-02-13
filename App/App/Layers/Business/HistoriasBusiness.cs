using App.Layers.Service;
using App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Layers.Business
{
    public class HistoriasBusiness
    {

        public IList<Models.HistoriaModel> ListarHistorias()
        {
            return new HistoriasService().GetHistorias();
        }

        public IList<Models.HistoriaModel> ListarHistoriasAutor(string id)
        {
            return new HistoriasService().GetHistoriasAutor(id);
        }

        public IList<Models.HistoriaModel> ListarHistoriasLeitor()
        {
            return new HistoriasService().GetHistoriasLeitor();
        }

        public IList<Models.HistoriaModel> ListarHistCategoria(String idCategoria)
        {
            return new HistoriasService().GetHistoriaCategoria(idCategoria);
        }

        public void CadastrarHistoria(HistoriaModel Historia,string Id)
        {
            new HistoriasService().CadastrarHistoria(Historia,Id);
        }
    
    }
}
