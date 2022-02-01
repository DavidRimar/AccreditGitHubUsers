using AccreditGitHubUsers.Models;
using AccreditGitHubUsers.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;


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
        // GET: api/GithubProfile

       

        [System.Web.Mvc.Route("api/GithubProfileApi")]
        [System.Web.Mvc.HttpGet]
        public async Task<IHttpActionResult> Get()
        {

            string url = "https://api.github.com/users/robconery";

            Profile = await _apiService.GetProfileAsync(url);

            //return View(Profile);
            return Ok(Profile);
        }

        [System.Web.Mvc.Route("api/GithubProfileApi/{searchString}")]
        [System.Web.Mvc.HttpGet]
        public async Task<IEnumerable<GithubProfile>> Get(string searchString)
        {

            string url = $"https://api.github.com/users/{searchString}";

            List<GithubProfile> list = new List<GithubProfile>();

            Profile = await _apiService.GetProfileAsync(url);

            list.Add(Profile);
            list.Add(Profile);

            //return View(Profile);
            return list;
        }


        /*
        public ActionResult Index()
        {
            //ViewBag.Title = "Home Page";

            return View(Profile);
        }
        */
    }
}
