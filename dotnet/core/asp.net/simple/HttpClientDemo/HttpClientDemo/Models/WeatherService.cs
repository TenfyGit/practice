using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientDemo.Models
{
    public class WeatherService
    {
        private HttpClient httpClient;
        public WeatherService(HttpClient client)
        {
            httpClient = client;
            httpClient.BaseAddress = new Uri("http://www.weather.com.cn");
            httpClient.Timeout = TimeSpan.FromSeconds(30);
        }
        public async Task<string> GetData()
        {
            var data = await httpClient.GetAsync("/data/sk/101010100.html");
            var message = await data.Content.ReadAsStringAsync();
            return message;
        }
    }
}
