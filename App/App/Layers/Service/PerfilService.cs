using App.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App.Layers.Service
{
    public class PerfilService
    {
        public void Cadastro(Models.PerfilModel perfil)
        {
            var _accessToken = AuthService.Auth();

            InserirPerfil(perfil,_accessToken);

        }
        

        public void InserirPerfil(Models.PerfilModel perfil, String _accessToken)
        {
            var _urlAccountApi = "https://na49.salesforce.com/services/data/v20.0/sobjects/Usuario__c/";

            var _body = "{ \"Name\" : \"" + perfil.Nome + "\" ," 
                +"\"Email__c\" : \"" + perfil.Email +"\" ," 
                + "\"Apelido__c\" : \"" + perfil.Apelido + "\" ,"
                + "\"Data_Nascimento__c\" : \"" + perfil.DataNascimento + "\" ,"
                + "\"Senha__c\" : \"" + perfil.Senha + "\" }";

            StringContent _conteudo = new StringContent(_body, Encoding.UTF8, "application/json");

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

        public Models.PerfilModel Login(LoginModel _login)
        {

            var _urlAccountApi = "https://na49.salesforce.com/services/data/v20.0/query/?q=SELECT+Senha__c,Email__c+FROM+Usuario__c+WHERE+Email__c='" +_login.Login + "'" ;

            HttpClient client = new HttpClient();
            var _accessToken = AuthService.Auth();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
            var response = client.GetAsync(_urlAccountApi).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                JObject objeto = JObject.Parse(conteudoResposta);

                PerfilModel _perfil = new PerfilModel();
                _perfil.Email = objeto["records"][0]["Email__c"].ToString();
                _perfil.Senha = objeto["records"][0]["Senha__c"].ToString();
                return _perfil;
            
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }

        
        public Models.PerfilModel BuscarDados(String email)
        {

            var _urlAccountApi = "https://na49.salesforce.com/services/data/v20.0/query/?q=SELECT+id,name,Email__c,Data_Nascimento__c+FROM+Usuario__c+WHERE+Email__c='" + email + "'";

            HttpClient client = new HttpClient();
            var _accessToken = AuthService.Auth();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
            var response = client.GetAsync(_urlAccountApi).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                JObject objeto = JObject.Parse(conteudoResposta);

                PerfilModel _perfil = new PerfilModel();
                _perfil.Nome = objeto["records"][0]["Name"].ToString();
                _perfil.Email = objeto["records"][0]["Email__c"].ToString();
                _perfil.DataNascimento = objeto["records"][0]["Data_Nascimento__c"].ToString();
                return _perfil;

            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }

        public String BuscarId(String email)
        {

            var _urlAccountApi = "https://na49.salesforce.com/services/data/v20.0/query/?q=SELECT+id+FROM+Usuario__c+WHERE+Email__c='" + email + "'";

            HttpClient client = new HttpClient();
            var _accessToken = AuthService.Auth();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
            var response = client.GetAsync(_urlAccountApi).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                JObject objeto = JObject.Parse(conteudoResposta);

                PerfilModel _perfil = new PerfilModel();
                _perfil.IdPerfil = objeto["records"][0]["Id"].ToString();
                return _perfil.IdPerfil;

            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }

        }

    }
}
