﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAOP
{
    public interface IUserProcessor
    {
        void RegUser(User user);
        int GetUserId();
    }
}
