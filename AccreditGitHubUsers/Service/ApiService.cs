using AccreditGitHubUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AccreditGitHubUsers.Service
{
    public class ApiService
    {

        public ApiService()
        {
                
        }

        public async Task<GithubProfile> GetProfileAsync(string path)
        {


            // string url = "";

            // using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url)) { };

            GithubProfile githubProfile = null;

            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                githubProfile = await response.Content.ReadAsAsync<GithubProfile>();
            }
            return githubProfile;
        }
    }
}