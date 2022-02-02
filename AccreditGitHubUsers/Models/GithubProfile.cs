using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccreditGitHubUsers.Models
{
    public class GithubProfile
    {
        public int Id { get; set; }

        [Display(Name = "Username")]
        public string Login { get; set; }

        [DisplayFormat(NullDisplayText = "Unknown Name")]
        public string Name { get; set; }

        public string Avatar_Url { get; set; }

        [DisplayFormat(NullDisplayText = "Unknown Location")]
        public string Location { get; set; }

        public string Repos_Url { get; set; }

        public ICollection<GithubProject> AllProjects { get; set; }
    }
}