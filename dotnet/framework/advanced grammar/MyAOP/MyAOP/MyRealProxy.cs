using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    /// <summary>
    /// 真实代理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyRealProxy<T>:RealProxy
    {
        private T tTarget;
        public MyRealProxy(T target)
            : base(typeof(T))
        {
            this.tTarget = target;
        }
        public override IMessage Invoke(IMessage msg)
        {
            BeforeProceed(msg);
            IMethodCallMessage callMessage = (IMethodCallMessage)msg;
            object returnValue = callMessage.MethodBase.Invoke(this.tTarget, callMessage.Args);
            AfterProceed(msg);
            return new ReturnMessage(returnValue,new object[0],0,null,callMessage);
        }
        public void BeforeProceed(IMessage msg)
        {
            Console.WriteLine("方法执行前可以加入的逻辑");
            
        }
        public void AfterProceed(IMessage msg)
        {
            Console.WriteLine("方法执行后可以加入的逻辑");
        }
    }
}
