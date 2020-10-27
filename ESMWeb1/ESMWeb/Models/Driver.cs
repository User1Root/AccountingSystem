using System;
using System.Collections.Generic;

namespace ESMWeb.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Esm = new HashSet<Esm>();
        }

        public long DriverId { get; set; }
        public string DriverFirstName { get; set; }
        public string DriverSecondName { get; set; }
        public long HomeDepot { get; set; }
        public long? HomeEsm { get; set; }

        public virtual Depot HomeDepotNavigation { get; set; }
        public virtual Esm HomeEsmNavigation { get; set; }
        public virtual ICollection<Esm> Esm { get; set; }
    }
}
