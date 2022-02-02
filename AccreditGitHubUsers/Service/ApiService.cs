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

        public async Task<List<GithubProject>> GetProjectsAsync(string path)
        {
            IList<GithubProject> projects = new List<GithubProject>() { };

            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                projects = await response.Content.ReadAsAsync<List<GithubProject>>();
            }
            else {
                
                // If StatusCode is not Ok, set to null, otherwise, it will be an empty list
                projects = null;
            }

            // if unsuccessful, returns empty list
            return (List<GithubProject>)projects;
        }
    }
}