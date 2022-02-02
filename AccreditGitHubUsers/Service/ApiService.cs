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
            List<GithubProject> allProjects = new List<GithubProject>() { };

            List<GithubProject> newProjects = new List<GithubProject>() { };

            
            int page = 1; // start from the first page
            int perPage = 100; // default is 30, max is 100

            // PAGINATION
            do
            {
                string pathWithPagination = path + $"?per_page={perPage}&page={page}"; 

                HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(pathWithPagination);

                if (response.IsSuccessStatusCode)
                {
                    newProjects = await response.Content.ReadAsAsync<List<GithubProject>>();

                    // add page result to list
                    allProjects.AddRange(newProjects);
                }
                else
                {
                    // If StatusCode is not Ok, set to null
                    allProjects = null;

                    break;
                }

                // increment page number
                page += 1;


            } while (newProjects.Count != 0); // while there are new projects on the page


            // if unsuccessful, returns empty list
            return allProjects;
        }
    }
}