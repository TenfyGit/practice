using System;

namespace Proxy
{
    public class RealSubject : Subject
    {
        public override string Request()
        {
            return "This is RealSubject";
        }
    }
}
