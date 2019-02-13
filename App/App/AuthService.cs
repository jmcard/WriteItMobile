using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace App
{
    public class AuthService
    {
        public static String Auth()
        {
            var _securityKey = ""; // Recebido por email
            var _clientSecret = "";
            var _clientId = "";
            var _redirectUri = "";
            var _grantAcess = "password";
            var _userName = "";
            var _password = "" + _securityKey;
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
    }
}
