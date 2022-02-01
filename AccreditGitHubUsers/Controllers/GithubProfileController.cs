using AccreditGitHubUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AccreditGitHubUsers.Controllers
{
    public class GithubProfileController : Controller
    {

        // PROPERTIES
        public GithubProfile GithubUser { get; set; }

        // CONSTRUCTOR
        public GithubProfileController()
        {

        }

        // ACTIONS
        public ActionResult Index()
        {
            // call Web API Controller from here
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44314/api/");

                //HTTP GET
                var responseTask = client.GetAsync("GithubProfileApi"); // calls the WEB API controller
                responseTask.Wait();

                var result = responseTask.Result;

                // check if Web API data fetch is successful
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<GithubProfile>();
                    readTask.Wait();

                    GithubUser = readTask.Result;
                }
                else //web api sent error response 
                {

                    GithubUser = null;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(GithubUser);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            // call Web API Controller from here using the Search String
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44314/api/");

                //HTTP GET
                var responseTask = client.GetAsync("GithubProfileApi/" + search); // calls the WEB API controller
                responseTask.Wait();

                var result = responseTask.Result;

                // check if Web API data fetch is successful
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<GithubProfile>();
                    readTask.Wait();

                    GithubUser = readTask.Result;

                }
                else //web api sent error response 
                {

                    GithubUser = null;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(GithubUser);
        }

       
    }
}
