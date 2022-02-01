using AccreditGitHubUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccreditGitHubUsers.Controllers
{
    public class GithubProfileController : Controller
    {

        // returns the Original View i.e. HOME PAGE == LIST of GitHub users
        // and a search button, upon which you get only certain users
        // otherwise, the top 5 or sth



        // shows a list of github users (5) with search enabled
        // model: LIST<GithubUser>
        // VIEW: Home > Index.cshtml
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(ListOfGithubUsers);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            ViewBag.Title = "Home Page";

            return View(ListOfGithubUsers.Where(user => user.Login.Contains(search)).ToList());
        }

        // PROPERTIES
        public List<GithubProfile> ListOfGithubUsers { get; set; }

        // CONSTRUCTOR
        public GithubProfileController()
        {
            ListOfGithubUsers = new List<GithubProfile>();
            ListOfGithubUsers.Add(new GithubProfile { Id = 1, Login = "robjones" });
            ListOfGithubUsers.Add(new GithubProfile { Id = 2, Login = "robconery" });
        }

        // Possible Action Handlers here that 
    }
}
