using AccountingSystemUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccountingSystemUI
{
    class AccountingSystemApi : IAccountingSystemUserApi
    {
        public Depot GetDepot()
        {
            throw new NotImplementedException();
        }

        public Driver GetDriverByNuber(string number)
        {
            throw new NotImplementedException();
        }

        public ESM GetESMByNumber(string number)
        {
            throw new NotImplementedException();
        }

        public void GiveESMToDriver(ESM esm, Driver driver)
        {
            throw new NotImplementedException();
        }

        public void TakeESMToTheDepot(ESM esm, Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
