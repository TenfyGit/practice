﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App
{
    public interface IFoo { }
    public interface IBar { }
    public interface IBaz { }
    public interface IGux { }
    public interface IFoobar<T1, T2> { }
    public class Base : IDisposable
    {
        public Base() => Console.WriteLine($"Instance of {GetType().Name} is created.");
        public void Dispose() => Console.WriteLine($"Instance of {GetType().Name} is disposed.");
    }
    public class Foo : Base, IFoo { }
    public class Bar : Base, IBar { }
    public class Baz : Base, IBaz { }
    [MapTo(typeof(IGux),Lifetime.Root)]
    public class Gux : Base, IGux { }
}
