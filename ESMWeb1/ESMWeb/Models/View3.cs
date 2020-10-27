using System;
using System.Collections.Generic;

namespace ESMWeb.Models
{
    public partial class View3
    {
        public long EsmId { get; set; }
        public long HomeDepot { get; set; }
        public byte Status { get; set; }
        public DateTime LastDateUsing { get; set; }
    }
}
