using AccreditGitHubUsers.Models;
using AccreditGitHubUsers.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace AccreditGitHubUsers.Controllers
{
    public class GithubProjectsApiController : ApiController
    {
        // PROPERTIES
        private ApiService _apiService { get; set; }

        public List<GithubProject> Projects { get; set; }

        // CONSTRUCTOR
        public GithubProjectsApiController()
        {

            _apiService = new ApiService();

            Projects = new List<GithubProject>();
           
        }

        // ACTIONS
        [System.Web.Mvc.Route("api/GithubProjectsApi/{search}")]
        public async Task<IHttpActionResult> Get(string search)
        {
            string url = $"https://api.github.com/users/{search}/repos";

            Projects = await _apiService.GetProjectsAsync(url);

            return Ok(Projects);
        }
    }
}
