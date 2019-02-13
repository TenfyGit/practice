using System;
using AbstractFactory.Factory;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            IFactory factory = new SqlServerFactory();//若要更改为Access数据库,只需要将本句改为IFactory factory = new AccessFactory();
            IUser iu = factory.CreateUser();
            iu.Insert(user);
            iu.GetUser(1);
            Console.ReadKey();
        }
    }
}
