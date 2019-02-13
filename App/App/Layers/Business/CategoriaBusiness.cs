using App.Layers.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Layers.Business
{
    public class CategoriaBusiness
    {
        public IList<Models.CategoriaModel> ListarCategorias()
        {
            return new CategoriaService().GetCategorias();
        }


    }
}
