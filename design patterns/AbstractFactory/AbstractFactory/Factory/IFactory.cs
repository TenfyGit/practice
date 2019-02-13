using System;

namespace AbstractFactory.Factory
{
    public interface IFactory
    {
        IUser CreateUser();
    }
}
