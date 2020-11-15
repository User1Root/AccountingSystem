using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountingSystemUI.Models
{
    public class UserWithToken
    {
        internal string AccessToken;

        internal string RefreshToken { get => AccountingSystemUI.Properties.Settings.Default["refreshtoken"].ToString(); }

        public UserWithToken(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            AccountingSystemUI.Properties.Settings.Default["refreshtoken"] = refreshToken;
        }                                                 
    }
}
