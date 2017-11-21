using System;
using KeycloakAuthRequestExample.Utils.HttpUtils;
using Newtonsoft.Json;
using RestSharp;

namespace KeycloakAuthRequestExample
{
    class Program
    {
        private static string username = "name";
        private static string password = "pass";
        private static string clientId = "clientid";
        private static string clientSecret = "somesecret";
        private static string realmName = "realmname";
        private static string keyCloakUrl = "www.keykloak.xmpl";

        static void Main(string[] args)
        {
            SendPostRequestToKeycloak($"https://{keyCloakUrl}/realms/{realmName}/protocol/openid-connect/token",
                "grant_type=password&" +
                $"username={username}&" +
                $"password={password}2&" +
                $"client_id={clientId}&" +
                $"client_secret={clientSecret}");

            Console.ReadLine();
        }

        public static void SendPostRequestToKeycloak(string keycloakUrl, string content)
        {
            HttpClientEx client = new HttpClientEx(new CondensedJsonSerializer());
            client.PostUrlEncodedAsync(keycloakUrl, content)
                .ContinueWith(task =>
            {
                string a = task.Result.Response.Content.ReadAsStringAsync().Result;
                var b = JsonConvert.DeserializeObject<KeycloakTokenResponseMessage>(a);
                Console.WriteLine(b.AccessToken);
            });
        }

        public static void SendThroughtPostSharp(string keycloakUrl, string content)
        {
            var client = new RestClient(keycloakUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", content, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);
        }
    }
}