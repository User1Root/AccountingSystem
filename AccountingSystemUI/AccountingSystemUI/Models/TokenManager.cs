using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountingSystemUI.Models
{
    public class TokenManager
    {
        private readonly static string _tokensManagerPath = "tokenManager.tnk";

        public static string AccessToken { get; private set; }

        public static string RefreshToken { get => GetRefreshToken(); }

        public static void Create(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            SetRefreshToken(refreshToken);                       
        }

        public static void Update(string accessToken)
        {
            AccessToken = accessToken;
        }
        
        public static void Clear()
        {
            if (File.Exists(_tokensManagerPath))
                File.Delete(_tokensManagerPath);
        }       

        private static void SetRefreshToken(string refreshtoken)
        {
            using (var writer = new StreamWriter(_tokensManagerPath))
            {
                writer.Write(refreshtoken);
            }
        }

        private static string GetRefreshToken()
        {
            if (!File.Exists(_tokensManagerPath))
                return null;
            string refreshToken = null; 
            using (var reader = new StreamReader(_tokensManagerPath))
            {
                refreshToken = reader.ReadToEnd();
            }
            return refreshToken;
        }
    }
}
