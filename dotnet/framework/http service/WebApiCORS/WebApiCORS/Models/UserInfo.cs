﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCORS.Models
{
    public class UserInfo
    {
        public bool bRes { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Ticket { get; set; }
    }
}