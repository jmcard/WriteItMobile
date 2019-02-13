using App.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace App.Layers.Service
{
    public class HistoriaService
    {

        public Models.HistoriaModel DadosHistoria()
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v20.0/query/?q=select+name,sinopse__c+from+Historia__c";

            HttpClient client = new HttpClient();
            var _accessToken = AuthService.Auth();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
            var response = client.GetAsync(_urlAccountApi).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                JObject objeto = JObject.Parse(conteudoResposta);

                HistoriaModel _historia = new HistoriaModel();
                _historia.TituloHistoria = objeto["records"][0]["Name"].ToString();
                _historia.Sinopse = objeto["records"][0]["Sinopse__c"].ToString();

                return _historia;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

    }
}
