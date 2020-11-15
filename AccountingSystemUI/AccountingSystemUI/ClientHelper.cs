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

        private static readonly string serverBaseUrl = @"https://localhost:44385/";

        private static readonly string LoginUrl = @"api/Users/Login";

        private static readonly string RefreshUrl = @"api/Users/RefreshToken";
        
        private static RestClient _client;

        private static UserWithToken _user;

        static ClientHelper()
        {
            _client = new RestClient(serverBaseUrl);
        }

        public  static  UserWithToken UserWithToken;

        public static async Task<HttpStatusCode> Login(string login,string password)
        {
            var request = new RestRequest(LoginUrl, Method.POST);
            request.AddJsonBody(new { username = login, userpassword = password });
            var response = await _client.ExecuteAsync<Dictionary<string,string>>(request);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                _user = new UserWithToken(response.Data["accessToken"], response.Data["refreshToken"]);
            }
            return response.StatusCode;
        }
      
        private static void RefreshToken()
        {
            var request = new RestRequest(LoginUrl, Method.POST);
            request.AddJsonBody(UserWithToken);
            var response = _client.Execute<Dictionary<string, string>>(request);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                UserWithToken.AccessToken = response.Data["accessToken"];
            }
            else if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                //выход из системы и повторная авторизация;
            }
            
        }
    }
}

