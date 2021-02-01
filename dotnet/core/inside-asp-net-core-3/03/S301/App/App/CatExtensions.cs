using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App
{
    public static class CatExtensions
    {
        public static T GetServices<T>(this Cat cat)
        {
            return default(T);
        }
    }
}
