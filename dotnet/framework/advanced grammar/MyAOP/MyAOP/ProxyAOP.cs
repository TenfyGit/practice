using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    /// <summary>
    /// 使用.Net Remoting/RealProxy 实现动态代理
    /// 局限在业务类必须是继承自MarshalByRefObject类型
    /// </summary>
    public class ProxyAOP
    {
        public void Show()
        {
            User user = new User()
            {
                Name = "S021453",
                Password = "123456"
            };
            UserProcessor processor = new UserProcessor();
            processor.RegUser(user);

            Console.WriteLine("********************");
            IUserProcessor userProcessor = TransparentProxy.Create<UserProcessor>();
            userProcessor.RegUser(user);
            int result = userProcessor.GetUserId();
        }
    }
}
