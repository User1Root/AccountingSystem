using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemUI.Models
{

    public interface IAccountingSystemUserApi
    {
        ESM GetESMByNumber(string number);

        Depot GetDepot();

        Driver GetDriverByNuber(string number);

        void TakeESMToTheDepot(ESM esm, Driver driver);

        void GiveESMToDriver(ESM esm, Driver driver);
    }
}
