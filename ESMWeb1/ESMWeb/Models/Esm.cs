using System;
using System.Collections.Generic;

namespace ESMWeb.Models
{
    public partial class Esm
    {
        public Esm()
        {
            Driver = new HashSet<Driver>();
        }

        public long EsmId { get; set; }
        public long HomeDepot { get; set; }
        public byte Status { get; set; }
        public long? LastDepot { get; set; }
        public long? LastDriver { get; set; }
        public DateTime LastDateUsing { get; set; }

        public virtual Depot HomeDepotNavigation { get; set; }
        public virtual Depot LastDepotNavigation { get; set; }
        public virtual Driver LastDriverNavigation { get; set; }
        public virtual ICollection<Driver> Driver { get; set; }
    }
}
