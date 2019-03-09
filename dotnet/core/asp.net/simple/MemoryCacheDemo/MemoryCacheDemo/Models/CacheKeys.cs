using System;

namespace MemoryCacheDemo.Models
{
    public class CacheKeys
    {
        public static string DependentCTS { get { return "_DependentCTS"; } }
        public static string UserSession { get { return "_UserSession"; } }
        public static string UserCart { get { return "_UserCart"; } }
        public static string UserShareData { get { return "_UserShareData"; } }
    }
}
