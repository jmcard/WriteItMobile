using App.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace App.Layers.Service
{
    public class HistoriasService
    {
        public IList<HistoriaModel> GetHistorias()
        {

            var _urlAccountApi = "https://na49.salesforce.com/services/data/v20.0/query/?q=select+name,sinopse__c,id,categoria__c+from+Historia__c";

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
                IList<HistoriaModel> historias = new List<HistoriaModel>();

                for (int i = 0; i < total; i++)
                {
                    HistoriaModel _historia = new HistoriaModel();
                    _historia.TituloHistoria = objeto["records"][i]["Name"].ToString();
                    _historia.Sinopse = objeto["records"][i]["Sinopse__c"].ToString();
                    _historia.IdHistoria = objeto["records"][i]["Id"].ToString();
              

                    historias.Add(_historia);
                }

                return historias;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }

        public IList<Models.HistoriaModel> GetHistoriasAutor(string id)
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v20.0/query/?q=select+name,sinopse__c,id,categoria__r.name+from+Historia__c+where+usuario__r.id="+"'"+id+"'";

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
                IList<HistoriaModel> historias = new List<HistoriaModel>();

                for (int i = 0; i < total; i++)
                {
                    HistoriaModel _historia = new HistoriaModel();
                    _historia.TituloHistoria = objeto["records"][i]["Name"].ToString();
                    _historia.Sinopse = objeto["records"][i]["Sinopse__c"].ToString();
                    _historia.IdHistoria = objeto["records"][i]["Id"].ToString();
                    

                    historias.Add(_historia);
                }

                return historias;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
            return null;
        }

        public IList<Models.HistoriaModel> GetHistoriasLeitor()
        {
            return null;
        }

        public IList<Models.HistoriaModel> GetHistoriaCategoria(String idCategoria)
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v20.0/query/?q=select+name,sinopse__c,id+from+Historia__c+where+categoria__c="+"'"+ idCategoria + "'";

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
                IList<HistoriaModel> historias = new List<HistoriaModel>();

                for (int i = 0; i < total; i++)
                {
                    HistoriaModel _historia = new HistoriaModel();
                    _historia.TituloHistoria = objeto["records"][i]["Name"].ToString();
                    _historia.Sinopse = objeto["records"][i]["Sinopse__c"].ToString();
                    _historia.IdHistoria = objeto["records"][i]["Id"].ToString();

                    historias.Add(_historia);
                }

                return historias;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public void CadastrarHistoria(HistoriaModel Historia, string Id)
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v20.0/sobjects/Historia__c/";

            var _body = "{ \"Name\" : \"" + Historia.TituloHistoria + "\" ,"
                + "\"Sinopse__c\" : \"" + Historia.Sinopse + "\" ,"
                + "\"Usuario__c\" : \"" + Id + "\" }";

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
