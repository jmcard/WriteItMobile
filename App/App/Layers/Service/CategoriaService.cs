using App.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace App.Layers.Service
{
    public class CategoriaService
    {

        public IList<CategoriaModel> GetCategorias()
        {

            var _urlAccountApi = "https://na49.salesforce.com/services/data/v20.0/query/?q=SELECT+name+FROM+Categoria__c";

            HttpClient client = new HttpClient();
            var _accessToken = AuthService.Auth();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
            var response = client.GetAsync(_urlAccountApi).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;

                JObject objeto = JObject.Parse(conteudoResposta);
                var total = Int32.Parse(objeto["totalSize"].ToString());
                IList<CategoriaModel> categorias = new List<CategoriaModel>();

                for (int i = 0; i < total; i++)
                {
                    CategoriaModel _categoria = new CategoriaModel();
                    _categoria.NomeCategoria = objeto["records"][i]["Name"].ToString();
                    categorias.Add(_categoria);
                }

                return categorias;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }

    }
}
