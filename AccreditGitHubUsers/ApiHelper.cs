using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace AccreditGitHubUsers
{
    public class ApiHelper
    {

        public static HttpClient ApiClient{ get; set; }

        public static void InitializeClient() {

            ApiClient = new HttpClient();
            // ApiClient.BaseAddress = new Uri("https://api.github.com/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Add("User-Agent", "DavidRimar");
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}