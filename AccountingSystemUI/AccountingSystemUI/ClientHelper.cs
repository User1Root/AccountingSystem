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
using System.Windows.Controls;

namespace AccountingSystemUI
{
    
    public static class ClientHelper
    {
        //TODO:Добавить в файл настроек.
        //как и все Url api. И обращаться через него. 

        #region Api Url
        private static readonly string _serverBaseUrl = @"https://localhost:44385/";

        private static readonly string _loginUrl = @"api/Users/Login";

        private static readonly string _refreshUrl = @"api/Users/RefreshToken";

        private static readonly string _getListOfDepots = @"api/Depots/";

        private static readonly string _getEsm = @"api/Depots/{id}/ESM";

        private static readonly string _getRecordedEsm = @"api/Depots/{id}/RecordedESM";

        private static readonly string _giveOutEsm = @"api/Esms/GiveOut/{id}";

        private static readonly string _takeEsm = @"api/Esms/Take/{id}";
        #endregion

        private static RestClient _client;

        internal static long DepotId { get; set; }

        internal static long UserId { get; private set; }       

        static ClientHelper()
        {
            _client = new RestClient(_serverBaseUrl);
        }

        /// <summary>
        /// Подключение. Проверяет валиден ли refresh token.
        /// </summary>
        /// <returns>Валиден ли refreshToken.</returns>
        public static void Connect(out bool isRefreshTokenValid)
        {
            if (_client == null)
                _client = new RestClient(_serverBaseUrl);
            isRefreshTokenValid = false;
            var refreshtoken = TokenManager.RefreshToken;
            if (refreshtoken != null)
            {
                isRefreshTokenValid = RefreshToken();
                return;
            }
        }

        public static event Action LogOutHandler;

        public static void LogOut()
        {
            TokenManager.Clear();
            LogOutHandler?.Invoke();
        }

        public static HttpStatusCode Login(string login,string password)
        {
            var request = new RestRequest(_loginUrl, Method.POST);
            request.AddJsonBody(new { username = login, userpassword = password });
            var response = _client.Execute<Dictionary<string,string>>(request);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                TokenManager.Create(response.Data["accessToken"], response.Data["refreshToken"]);
                UserId = Convert.ToInt64(response.Data["userId"]);
            }
            return response.StatusCode;
        }
      
        private static bool RefreshToken()
        {
            var request = new RestRequest(_refreshUrl, Method.POST);
            if (TokenManager.RefreshToken == null)
                return false;

            request.AddJsonBody(new { refreshToken = TokenManager.RefreshToken});
            var response = _client.Execute<Dictionary<string, string>>(request);
            if(response.StatusCode == HttpStatusCode.OK)
            {
                TokenManager.Update(response.Data["accessToken"]);
                UserId = Convert.ToInt64(response.Data["userId"]);
                return true;
            }

            return false;
        }

        public static void DepotIdWasChanged(object sender, SelectionChangedEventArgs args)
        {
            var comboBox = sender as ComboBox;
            DepotId = Convert.ToInt64(comboBox.SelectedItem.ToString().Split(':')[0]);
        }                     

        public static Tuple<HttpStatusCode, Depot[]> GetDepots()
        {
            var request = new RestRequest(_getListOfDepots, Method.GET);           
            var responseData = GetResponse<Depot[]>(request);
            return responseData;
        }

        public static Tuple<HttpStatusCode, Depot> GetEsm()
        {
            var request = new RestRequest(_getEsm, Method.GET);
            request.AddUrlSegment("id", DepotId.ToString());
            return GetResponse<Depot>(request);
        }

        public static Tuple<HttpStatusCode, Depot> GetRecordedEsm()
        {
            var request = new RestRequest(_getRecordedEsm, Method.GET);
            request.AddUrlSegment("id", DepotId.ToString());
            return GetResponse<Depot>(request);
        }

        public static Tuple<HttpStatusCode, ESM> GiveOutEsm(long driverId, long esmId)
        {
            var request = new RestRequest(_giveOutEsm, Method.PUT);
            request.AddUrlSegment("id", esmId.ToString());
            request.AddJsonBody(new ESM() { EsmId = esmId, LastDriver = driverId, LastDepot = DepotId }) ;
            return GetResponse<ESM>(request);
        }

        public static Tuple<HttpStatusCode, ESM> TakeEsm(long driverId, long esmId)
        {
            var request = new RestRequest(_takeEsm, Method.PUT);
            request.AddUrlSegment("id", esmId.ToString());
            request.AddJsonBody(new ESM() { EsmId = esmId, LastDriver = driverId, LastDepot = DepotId });
            return GetResponse<ESM>(request);
        }

        private static Tuple<HttpStatusCode,T> GetResponse<T>(RestRequest request)
        {            
            for (var i = 0; i < 2; i++)
            {
                request.AddHeader("Authorization", string.Format("Bearer {0}", TokenManager.AccessToken));
                var response = _client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<T>(response.Content);
                    return new Tuple<HttpStatusCode, T>(response.StatusCode, result);
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    var isRefreshTokenValid = RefreshToken();
                    if (isRefreshTokenValid)
                        continue;
                    else
                    {
                        return new Tuple<HttpStatusCode, T>(response.StatusCode, default(T));
                    }
                }
                else
                {
                    return new Tuple<HttpStatusCode, T>(0, default(T));
                }
            }

            return new Tuple<HttpStatusCode, T>(0, default(T));
        }

    }
}

