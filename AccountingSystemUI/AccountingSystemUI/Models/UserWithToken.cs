using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountingSystemUI.Models
{
    //TODO:придумать как хранить эти токены правильно.
    //Думаю refresh в файл(шифр.) а access только для оперативки.
    public static class UserWithToken
    {
        public static string AccessToken { get; private set; }

        public static string RefreshToken { get => AccountingSystemUI.Properties.Settings.Default["refreshtoken"].ToString(); }

        public static void UpdateUser(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            AccountingSystemUI.Properties.Settings.Default["refreshtoken"] = refreshToken;
        }
        
        public static void LogOut()
        {
            AccountingSystemUI.Properties.Settings.Default["refreshtoken"] = string.Empty;
            AccessToken = string.Empty;
        }

        public static void UpdateAccessToken(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
