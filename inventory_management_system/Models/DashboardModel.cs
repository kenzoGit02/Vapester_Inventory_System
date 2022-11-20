using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inventory_management_system.Models
{
    public class DashboardModel
    {
        public List<TellerCountModel> DboardTeller { get; set; }

        public List<ProductCountModel> DboardProduct { get; set; }
    }
}