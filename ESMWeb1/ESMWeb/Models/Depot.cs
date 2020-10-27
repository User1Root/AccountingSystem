using System;
using System.Collections.Generic;

namespace ESMWeb.Models
{
    public partial class Depot
    {
        public Depot()
        {
            Driver = new HashSet<Driver>();
            EsmHomeDepotNavigation = new HashSet<Esm>();
            EsmLastDepotNavigation = new HashSet<Esm>();
        }

        public long DepotId { get; set; }
        public string DepotName { get; set; }

        public virtual ICollection<Driver> Driver { get; set; }
        public virtual ICollection<Esm> EsmHomeDepotNavigation { get; set; }
        public virtual ICollection<Esm> EsmLastDepotNavigation { get; set; }
    }
}
