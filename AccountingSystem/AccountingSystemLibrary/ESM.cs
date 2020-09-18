using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemLibrary
{
    public class ESM
    {
        public int Id { get; set; }

        public Driver Driver { get;}

        public Depot MainDepot { get;}

        public Depot LocalDepot { get;}

        public bool Status => LocalDepot == null;

        public ESM(Depot mainDepot,Driver driver, Depot localDepot = null)
        {
            MainDepot = mainDepot;
            Driver = driver;
            LocalDepot = localDepot;
        }

    }
}
