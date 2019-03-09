using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace UserCenterDemoTest
{
    public class HomeControllerTest
    {
        public static TestServer testServer;
        public static HttpClient httpClient;
        public HomeControllerTest()
        {
            if(testServer == null)
            {
                testServer = new TestServer(new WebHostBuilder().UseStartup<UserCenterDemo.Startup>());
                httpClient = testServer.CreateClient();
            }
        }
        
        [Fact]
        public async void GetUserNameTest()
        {
            var data = await httpClient.GetAsync("/home/get/100");
            var result = await data.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<TestResult>(result);
            Assert.Equal(0,obj.Code);
        }
        [Fact]
        public async void GetGuestTest()
        {
            var data = await httpClient.GetAsync("/home/get/0");
            var result = await data.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<TestResult>(result);
            System.Console.WriteLine(result);
            Assert.Equal(403,obj.Code);
        }
    }
    public class TestResult
    {
        public int Code{get;set;}
        public string UserName{get;set;}
    }
}
