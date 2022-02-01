using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccreditGitHubUsers.Models
{
    public class GithubProject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Full_Name { get; set; }

        public GithubProfile Owner { get; set; }

        public int Forks_Count { get; set; }

        public int Stargazers_Count { get; set; }

        public int Open_Issues_Count { get; set; }

        public int Watchers { get; set; }

    }
}