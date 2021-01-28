using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S102
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder()
                .ConfigureWebHost(builder=>
                    builder.UseKestrel()
                    .UseUrls("http://localhost:8012")
                    .Configure(app=>app.Run(context=>context.Response.WriteAsync("Hello World!"))))
                .Build()
                .Run();
        }

    }
}
