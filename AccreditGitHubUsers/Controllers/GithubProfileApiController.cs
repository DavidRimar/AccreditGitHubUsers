using AccreditGitHubUsers.Models;
using AccreditGitHubUsers.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace AccreditGitHubUsers.Controllers
{
    public class GithubProfileApiController : ApiController
    {
        // PROPERTIES
        private ApiService _apiService { get; set; }

        public List<GithubProject> Projects { get; set; }

        public GithubProfile Profile { get; set; }

        // CONSTRUCTOR
        public GithubProfileApiController()
        {

            _apiService = new ApiService();

            Projects = new List<GithubProject>();

            Profile = new GithubProfile { Id = 1, Login = "User1", AllProjects = Projects };
            
            Projects.Add(new GithubProject { Id = 1, ProjectName = "Project 1", Owner = Profile});
            Projects.Add(new GithubProject { Id = 2, ProjectName = "Project 2", Owner = Profile });
        }

        // ACTIONS
        [System.Web.Mvc.Route("api/GithubProfileApi")]
        public async Task<GithubProfile> Get()
        {

            string url = "https://api.github.com/users/DavidRimar"; // Default value, if no search string, give me David Rimar

            Profile = await _apiService.GetProfileAsync(url);

            return Profile;
        }

        [System.Web.Mvc.Route("api/GithubProfileApi/{search}")]
        public async Task<GithubProfile> Get(string search)
        {

            string url = $"https://api.github.com/users/{search}";

            Profile = await _apiService.GetProfileAsync(url);

            return Profile;
        }

    }
}
