using AccreditGitHubUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace AccreditGitHubUsers.Controllers
{
    public class GithubProjectsController : Controller
    {

        // PROPERTIES
        public GithubProfile GithubUser { get; set; }

        // CONSTRUCTOR
        public GithubProjectsController()
        {
            
        }
        // is the controller getting the object from ActionLink or Index???
        // ACTIONS
        public ActionResult Index(GithubProfile githubUser)
        {

            // use the GithubProfile object from the Profile page
            GithubUser = githubUser;
            githubUser.AllProjects = new List<GithubProject>();

            // call Web API Controller from here using the Search String
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44314/api/");

                //HTTP GET
                var responseTask = client.GetAsync("GithubProjectsApi/" + GithubUser.Login); // calls the WEB API controller
                responseTask.Wait();

                var result = responseTask.Result;

                // check if Web API data fetch is successful
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<GithubProject>>();
                    readTask.Wait();

                    if (readTask.Result.Count != 0) {

                        GithubUser.AllProjects = readTask.Result.OrderByDescending(x => x.Stargazers_Count).Take(5).ToList();

                    }

                }
                else //web api sent error response 
                {

                    GithubUser.AllProjects = (ICollection<GithubProject>)Enumerable.Empty<GithubProject>(); ; // empty the list

                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }

            return View(GithubUser);
        }

       
    }
}
