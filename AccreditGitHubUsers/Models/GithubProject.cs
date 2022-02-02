using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccreditGitHubUsers.Models
{
    public class GithubProject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Full Name")]
        public string Full_Name { get; set; }

        public string Description { get; set; }

        public GithubProfile Owner { get; set; }

        [Display(Name = "Stargazers")]
        public int Stargazers_Count { get; set; }

        public string Svn_Url { get; set; }

    }
}