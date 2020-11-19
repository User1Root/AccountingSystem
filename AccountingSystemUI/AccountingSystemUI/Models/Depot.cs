using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemUI.Models
{
    public class Depot
    {
        public long depotId { get; set; }
        public string depotName { get; set; }
        public ESM[] EsmHomeDepotNavigation { get; set; }
        public ESM[] EsmLastDepotNavigation { get; set; }
    }
}

