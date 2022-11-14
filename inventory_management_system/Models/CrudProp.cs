using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inventory_management_system.Models
{
    public class CrudProp
    {
        public int prod_Id { get; set; }
        public string prod_Name { get; set; }
        public int prod_Stock { get; set; }
        public string prod_Type { get; set; }
        public string prod_Variant { get; set; }
    }
}