using AccreditGitHubUsers.Controllers;
using AccreditGitHubUsers.Models;
using AccreditGitHubUsers.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace AccreditGitHubUsers.Tests.Controllers
{
    [TestClass]
    public class GithubProfileApiControllerTest
    {

        // 1. No Paramter to Get > Default User Returned
        // 2. Valid Username Supplied > User Returned
        // 3. Invalid Username Supplied > NotFound Returned

        [TestMethod]
        public async Task Get_NoParameterPassed_OkResponseReturned()
        {
            // Arrange
            GithubProfileApiController controller = new GithubProfileApiController();
            ApiHelper.InitializeClient();

            // Act
            IHttpActionResult result = await controller.Get();
            var contentResult = result as OkNegotiatedContentResult<GithubProfile>;
            var expectedName = "DavidRimar";

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedName, contentResult.Content.Login);
        }

        [TestMethod]
        public async Task Get_ValidUserNamePassed_OkResponseReturned()
        {
            // Arrange
            GithubProfileApiController controller = new GithubProfileApiController();
            ApiHelper.InitializeClient();
            string username = "robconery";

            // Act
            IHttpActionResult result = await controller.Get(username);
            var contentResult = result as OkNegotiatedContentResult<GithubProfile>;
            var expectedName = "Rob Conery";

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedName, contentResult.Content.Name);
        }

        [TestMethod]
        public async Task Get_InvalidUserNamePassed_NotFoundReturned()
        {
            // Arrange
            GithubProfileApiController controller = new GithubProfileApiController();
            ApiHelper.InitializeClient();
            string username = "robconer";

            // Act
            IHttpActionResult result = await controller.Get(username);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

    }
}
