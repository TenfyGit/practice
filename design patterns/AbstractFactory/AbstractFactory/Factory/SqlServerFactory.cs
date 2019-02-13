using System;

namespace AbstractFactory.Factory
{
    public class SqlServerFactory:IFactory
    {
        public IUser CreateUser()
        {
            return new SqlServerUser();
        }
    }
}
