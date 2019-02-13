using System;

namespace AbstractFactory.Factory
{
    public class AccessUser:IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("Add a record to the user table in Access");
        }
        public User GetUser(int id)
        {
            Console.WriteLine("In the Access,get a record of the user table by id");
            return null;
        }
    }
}
