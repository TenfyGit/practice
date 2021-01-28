using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S103
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(builder=>
                    builder.ConfigureServices(service=>
                    service.AddRouting()
                    .AddControllersWithViews())
                    .Configure(app=>
                    app.UseRouting()
                    .UseEndpoints(e=>
                    e.MapControllers())))
                .Build()
                .Run();
        }

    }
}