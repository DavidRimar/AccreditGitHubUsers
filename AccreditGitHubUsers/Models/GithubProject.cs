using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccreditGitHubUsers.Models
{
    public class GithubProject
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public GithubProfile Owner { get; set; }

        public int NumberOfForks { get; set; }
    }
}