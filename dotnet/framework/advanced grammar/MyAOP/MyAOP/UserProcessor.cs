using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    public class UserProcessor : MarshalByRefObject,IUserProcessor
    {

        public void RegUser(User user)
        {
            Console.WriteLine("用戶名稱:{0} Password:{1}",user.Name,user.Password);
        }

        public int GetUserId()
        {
            return 123;
        }
    }
}
