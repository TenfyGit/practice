using System;

namespace AbstractFactory.Factory
{
    public class AccessFactory
    {
        public IUser CreateUser()
        {
            return new AccessUser();
        }
    }
}
