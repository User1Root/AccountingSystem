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

namespace AccountingSystemUI
{
    public static class ClientHelper
    {
        static HttpClient client = new HttpClient();

        static ClientHelper()
        {
            Run();
        }

        public static async Task<ESM> GetESMAsync(string path)
        {
            ESM esm = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {

                esm = await response.Content.ReadAsAsync<ESM>();
                
            }
            return esm;
        }

        public static async Task<Driver> GetDriverAsync(string path)
        {
            Driver driver = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {

                driver = await response.Content.ReadAsAsync<Driver>();

            }

            return driver;
        }

        public static async Task<Depot> GetDepotAsync(string path)
        {
            Depot depot = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {

                depot = await response.Content.ReadAsAsync<Depot>();

            }
            return depot;
        }

        public static async Task<ESM> UpdateProductAsync(ESM esm)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/products/{esm.number}", esm);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            esm = await response.Content.ReadAsAsync<ESM>();
            return esm;
        }

        static async void Run()
        {
            //спятать ссылки в appsetting
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //var request = new HttpRequestMessage
            //{
            //    RequestUri = new Uri("api/ESM/1"),
            //    Method = HttpMethod.Get,
            //    Headers =
            //    {
            //       { HttpRequestHeader.Authorization.ToString(), "[your authorization token]" },
            //       { HttpRequestHeader.ContentType.ToString(), "multipart/mixed" }
            //    },                
            //
            //};

            //var res = await client.SendAsync(request);            

           
        }
    }
}

