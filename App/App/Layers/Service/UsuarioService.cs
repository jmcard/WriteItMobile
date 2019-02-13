﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace App.Layers.Service
{
    public class UsuarioService
    {
        public void Acessar()
        {
            var _accessToken = Auth();

            InvokeSalesForceAccountApi(_accessToken);

            RetornarAccess(_accessToken);

            Console.Read();
        }
        public static void InvokeSalesForceAccountApi(string _accessToken)
        {
            var _urlAccountApi = "https://na59.salesforce.com/services/data/v20.0/sobjects/Account/";

            var _body = "{ \"Name\" : \"PEPPA\" }";

            StringContent _conteudo = new StringContent(_body, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken);
            var response = client.PostAsync(_urlAccountApi, _conteudo).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(conteudoResposta);

                Console.WriteLine("Id da Conta Gerado: " + json.id);

            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }


        }
        public static String Auth()
        {
            var _securityKey = "oH1Df1B9qlFzyreWvnLdW1spE"; // Recebido por email
            var _clientSecret = "7659733653278729108";
            var _clientId = "3MVG9zlTNB8o8BA3A_5yAyYlAgsNcupQtBmDC.hunKP2OJ00IMscoi7GctPIOSMdvlJeOUFfYGppPrGUid6ct";
            var _redirectUri = "http://www.fiap.com.br";
            var _grantAcess = "password";
            var _userName = "julia.cardoso1306@gmail.com";
            var _password = "FF!130697" + _securityKey;
            var _urlSalesForceAuth = "https://login.salesforce.com/services/oauth2/token";

            var parameters = new Dictionary<string, string> {
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "redirect_uri" , _redirectUri },
                { "grant_type" , _grantAcess },
                { "username" , _userName },
                { "password" , _password },
            };

            var encodedContent = new FormUrlEncodedContent(parameters);

            HttpClient client = new HttpClient();
            var response = client.PostAsync(_urlSalesForceAuth, encodedContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var conteudoResposta = response.Content.ReadAsStringAsync().Result;
                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(conteudoResposta);

                return json.access_token;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public String RetornarAccess(String _accessToken)
        {
            return _accessToken;
        }
    }
}