using System.Threading.Tasks;
using CMS.Manar.Models.TokenAuth;
using CMS.Manar.Web.Controllers;
using Shouldly;
using Xunit;

namespace CMS.Manar.Web.Tests.Controllers
{
    public class HomeController_Tests: ManarWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}