using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AccreditGitHubUsers
{
    public class ApiHelper
    {

        public static HttpClient ApiClient{ get; set; }

        public static void InitializeClient() {

            string token = "";

            ApiClient = new HttpClient();
            // ApiClient.BaseAddress = new Uri("https://api.github.com/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Add("User-Agent", "AccreditGitHubUsers");
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", token);
        }
    }
}