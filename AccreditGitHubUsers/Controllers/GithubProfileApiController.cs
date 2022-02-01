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

        public GithubProfile Profile { get; set; }

        // CONSTRUCTOR
        public GithubProfileApiController()
        {

            _apiService = new ApiService();

            Profile = new GithubProfile { };
           
        }

        // ACTIONS
        [System.Web.Mvc.Route("api/GithubProfileApi")]
        public async Task<IHttpActionResult> Get()
        {

            string url = "https://api.github.com/users/DavidRimar"; // Default value, if no search string, give me David Rimar

            Profile = await _apiService.GetProfileAsync(url);

            if (Profile == null)
            {
                return NotFound();
            }

            return Ok(Profile);
        }

        [System.Web.Mvc.Route("api/GithubProfileApi/{search}")]
        public async Task<IHttpActionResult> Get(string search)
        {

            string url = $"https://api.github.com/users/{search}";

            Profile = await _apiService.GetProfileAsync(url);

            if (Profile == null)
            {
                return NotFound();
            }

            return Ok(Profile);
        }

    }
}
