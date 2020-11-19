using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemUI.Models
{
    public class ESM
    {
        public long EsmId { get; set; }
        public byte Status { get; set; }
        public long? LastDriver { get; set; }
        public long? LastDepot { get; set; }
    }
}
