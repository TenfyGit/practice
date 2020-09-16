using System;
using System.Net.Http;
using IdentityModel.Client;

namespace ThirdPartyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var diso = client.GetDiscoveryDocumentAsync("http://localhost:5000").Result;
            if (diso.IsError)
            {
                Console.WriteLine(diso.Error);
            }

            var tokenResponse = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest()
            {
                Address = diso.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api"
            }).Result;
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
            }
            else
            {
                Console.WriteLine(tokenResponse.Json);
                client.SetBearerToken(tokenResponse.AccessToken);
                var result = client.GetAsync("http://localhost:5001/api/values").Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine(result.Content.ReadAsStringAsync().Result);
                }
            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
