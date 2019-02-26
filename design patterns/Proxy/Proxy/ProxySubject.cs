using System;

namespace Proxy
{
    public class ProxySubject : Subject
    {
        RealSubject realSubject;
        public override string Request()
        {
            if(realSubject == null)
            {
                realSubject = new RealSubject();
            }
            return realSubject.Request();
        }
    }
}
