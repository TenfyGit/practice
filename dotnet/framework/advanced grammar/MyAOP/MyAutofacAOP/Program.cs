using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;

namespace MyAutofacAOP
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            //动态注入拦截器CallLogger 启动接口代理拦截
            builder.RegisterType<Circle>().As<IShape>().InterceptedBy(typeof(CallLogger)).EnableInterfaceInterceptors();
            //注入拦截器到容器
            builder.Register(c => new CallLogger(Console.Out));
            //创建容器
            var container = builder.Build();
            //从容器获取类型
            var circle = container.Resolve<IShape>();
            circle.Area();
            Console.ReadKey();
        }
    }
}
