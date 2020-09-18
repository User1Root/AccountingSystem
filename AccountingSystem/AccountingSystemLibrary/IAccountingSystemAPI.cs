using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingSystemLibrary
{
    public interface IAccountingSystemAPI
    {
        bool Authorization(int id, string password);
    }
}
