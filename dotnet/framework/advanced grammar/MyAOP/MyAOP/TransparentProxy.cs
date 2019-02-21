using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    /// <summary>
    /// 透明代理
    /// </summary>
    public static class TransparentProxy
    {
        public static T Create<T>()
        {
            T instance = Activator.CreateInstance<T>();
            MyRealProxy<T> realProxy = new MyRealProxy<T>(instance);
            T transparentProxy = (T)realProxy.GetTransparentProxy();
            return transparentProxy;
        }
    }
}
