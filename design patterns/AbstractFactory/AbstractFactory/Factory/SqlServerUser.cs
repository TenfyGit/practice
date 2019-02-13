using System;

namespace AbstractFactory.Factory
{
    public class SqlServerUser:IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("Add a record to the user table in sql server");
        }
        public User GetUser(int id)
        {
            Console.WriteLine("In the sql server,get a record of the user table by id");
            return null;
        }
    }
}
