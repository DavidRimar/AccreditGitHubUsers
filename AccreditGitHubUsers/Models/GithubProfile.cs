using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccreditGitHubUsers.Models
{
    public class GithubProfile
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Name { get; set; }
        
        public string Repos_Url { get; set; }

        public ICollection<GithubProject> AllProjects { get; set; }
    }
}