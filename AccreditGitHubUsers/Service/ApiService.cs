using AccreditGitHubUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AccreditGitHubUsers.Service
{
    public class ApiService : IApiService
    {

        public ApiService()
        {
                
        }

        public async Task<GithubProfile> GetProfileAsync(string path)
        {

            GithubProfile githubProfile = null;

            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                githubProfile = await response.Content.ReadAsAsync<GithubProfile>();
            }
            // if unsuccessful, returns null
            return githubProfile;
        }
    }
}