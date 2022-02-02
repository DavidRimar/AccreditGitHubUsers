using AccreditGitHubUsers.Controllers;
using AccreditGitHubUsers.Models;
using AccreditGitHubUsers.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace AccreditGitHubUsers.Tests.Controllers
{
    [TestClass]
    public class GithubProjectsApiControllerTest
    {

        // 1. Projects Exist > Ok Result returned and Non-Empty ProjectList Returned
        // 2. Projects Do Not Exist > Ok Result returned and Empty ProjectList Returned
        // 3. Github API is down > NotFound

        [TestMethod]
        public async Task Get_ProjectsExistForUser_OkResponseNonEmptyProjectsReturned()
        {
            // Arrange
            GithubProfileApiController controller = new GithubProfileApiController();
            ApiHelper.InitializeClient();
            string username = "robconery";

            // Act
            IHttpActionResult result = await controller.Get(username);
            var contentResult = result as OkNegotiatedContentResult<List<GithubProject>>;
            var expectedNumberOfProjects = 5;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedNumberOfProjects, contentResult.Content.Count);
        }

        [TestMethod]
        public async Task Get_NoProjectForUser_OkResponseEmptyProjectsReturned()
        {
            // Arrange
            GithubProjectsApiController controller = new GithubProjectsApiController();
            ApiHelper.InitializeClient();
            string username = "techyay";

            // Act
            IHttpActionResult result = await controller.Get(username);
            var contentResult = result as OkNegotiatedContentResult<List<GithubProject>>;
            var expectedNumberOfProjects = 0;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedNumberOfProjects, contentResult.Content.Count);
        }

        [TestMethod]
        public async Task Get_BadRequest_NotFoundReturned()
        {
            // Arrange
            GithubProjectsApiController controller = new GithubProjectsApiController();
            ApiHelper.InitializeClient();
            string username = "robconer";

            // Act
            IHttpActionResult result = await controller.Get(username);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

    }
}
