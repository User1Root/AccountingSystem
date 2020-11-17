using AccountingSystemUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using RestSharp;

namespace AccountingSystemUI
{
    
    public static class ClientHelper
    {
        //TODO:Добавить в файл настроек.
        //как и все Url api. И обращаться через него. 
        #region Api Url
        private static readonly string serverBaseUrl = @"https://localhost:44385/";

        private static readonly string LoginUrl = @"api/Users/Login";

        private static readonly string RefreshUrl = @"api/Users/RefreshToken";
        #endregion

        private static RestClient _client;

        internal static long UserId { get; private set; }

        static ClientHelper()
        {
            _client = new RestClient(serverBaseUrl);                
        }

        internal static void Connect()
        {
            if (_client == null)
                _client = new RestClient(serverBaseUrl);
        }

        internal static void LogOut()
        {
            UserWithToken.LogOut();           
        }

        internal static async Task<HttpStatusCode> Login(string login,string password)
        {
            var request = new RestRequest(LoginUrl, Method.POST);
            request.AddJsonBody(new { username = login, userpassword = password });
            var response = await _client.ExecuteAsync<Dictionary<string,string>>(request);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                UserWithToken.UpdateUser(response.Data["accessToken"], response.Data["refreshToken"]);
                UserId = Convert.ToInt64(response.Data["userId"]);
            }
            return response.StatusCode;
        }
      
        private async static Task<bool> RefreshToken()
        {
            var request = new RestRequest(RefreshUrl, Method.POST);
            request.AddJsonBody(new { accessToken = UserWithToken.AccessToken, refreshToken = UserWithToken.RefreshToken });
            var response = await _client.ExecuteAsync<Dictionary<string, string>>(request);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                UserWithToken.UpdateAccessToken(response.Data["accessToken"]);
                UserId = Convert.ToInt64(response.Data["userId"]);
                return true;
            }

            return false;
        }

        

    }
}

