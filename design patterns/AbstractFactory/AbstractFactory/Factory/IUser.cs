using System;

namespace AbstractFactory.Factory
{
    public interface IUser
    {
        void Insert(User user);
        User GetUser(int id);
    }
}
