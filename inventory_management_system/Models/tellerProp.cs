﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inventory_management_system.Models
{
    public class tellerProp
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
    }
}