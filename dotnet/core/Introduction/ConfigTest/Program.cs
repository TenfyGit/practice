using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration.Json;

namespace ConfigTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Machine);
            var initData = new List<KeyValuePair<string, string>>();
            initData.Add(new KeyValuePair<string, string>("username", "内存变量"));
            IConfiguration configuration = new ConfigurationBuilder()
                                            .SetBasePath(Environment.CurrentDirectory)//安装Microsoft.Extensions.Configuration.Json
                                            .AddJsonFile($"appsettings.json",optional:true,reloadOnChange:true)//第三个参数为是否热加载
                                            .AddXmlFile("appsettings.xml") //安装Microsoft.Extensions.Configuration.Xml
                                            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                                            .AddInMemoryCollection(initData)//添加内存数据源
                                            .Build();
            string username = configuration["username"];
            var mySql = configuration.GetSection("MySql").Get<MySql>();//安装Microsoft.Extensions.Configuration.Binder
            string host = configuration.GetSection("MySql").GetSection("Host").Value;
            int port = configuration.GetValue<int>("MySql:Port", 0); //需安装Microsoft.Extensions.Configuration.Binder
            Console.WriteLine(username);
            Console.ReadKey();
        }
    }
}
