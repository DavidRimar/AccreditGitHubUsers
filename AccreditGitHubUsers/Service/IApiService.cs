using AccreditGitHubUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccreditGitHubUsers.Service
{
    public interface IApiService
    {
        Task<GithubProfile> GetProfileAsync(string path);
    }
}
