using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemLibrary
{
    public class Depot
    {
        public string Name { get; }

        public int Id { get; set; }

        public List<ESM> Esms;



        public Depot(List<ESM> esms)
        {
            Esms = esms;
        }
    }
}
