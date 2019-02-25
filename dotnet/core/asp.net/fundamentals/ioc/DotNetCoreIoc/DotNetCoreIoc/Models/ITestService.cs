using System;
using System.Collections.Generic;

namespace DotNetCoreIoc.Models
{
    public interface ITestService
    {
        Guid MyProperty { get; }
        List<string> GetList(string a);
    }
}
