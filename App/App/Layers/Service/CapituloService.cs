using App.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace App.Layers.Service
{
    public class CapituloService
    {
        public Models.CapituloModel GetCapitulo(String id)
        {
            var _urlAccountApi = "https://na59.salesforce.com/services/data/v20.0/query/?q=SELECT+name,texto__c+FROM+Chapter__c+where+historia__r.Id='" + id + "'";

            HttpClient client = new HttpClient();
            var _accessToken = AuthService.Auth();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
            var response = client.GetAsync(_urlAccountApi).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                JObject objeto = JObject.Parse(conteudoResposta);

                CapituloModel _capitulo = new CapituloModel();
                _capitulo.TituloCapitulo = objeto["records"][0]["Name"].ToString();
                _capitulo.Texto = objeto["records"][0]["Texto__c"].ToString();

                return _capitulo;

            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }

        public IList<Models.CapituloModel> GetCapitulos(String id)
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v20.0/query/?q=SELECT+name,texto__c+FROM+capitulo__c+where+historia__r.id='" + id + "'";

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
                IList<CapituloModel> capitulos = new List<CapituloModel>();

                for (int i = 0; i < total; i++)
                {
                    CapituloModel _capitulo = new CapituloModel();
                    _capitulo.TituloCapitulo = objeto["records"][i]["Name"].ToString();
                    _capitulo.Texto = objeto["records"][i]["Texto__c"].ToString();
                    capitulos.Add(_capitulo);
                }

                return capitulos;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public void CadastrarCapitulo(CapituloModel Capitulo, String Id)
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v20.0/sobjects/Capitulo__c/";

            var _body = "{ \"Name\" : \"" + Capitulo.TituloCapitulo + "\" ,"
                + "\"Texto__c\" : \"" + Capitulo.Texto + "\" ,"
                + "\"Historia__c\" : \"" + Id + "\" }";

            StringContent _conteudo = new StringContent(_body, Encoding.UTF8, "application/json");
            var _accessToken = AuthService.Auth();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
            var response = client.PostAsync(_urlAccountApi, _conteudo).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(conteudoResposta);

            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }
    }
}
