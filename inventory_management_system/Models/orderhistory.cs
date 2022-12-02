using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inventory_management_system.Models
{
    public class orderhistory
    {
        public int Order_ID { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }

        public int prod_ID { get; set; }

        public DateTime date { get; set; }
    }
}