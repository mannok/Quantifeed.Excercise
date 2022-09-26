using System.Threading.Tasks;
using Quantifeed.Excercise.Models.TokenAuth;
using Quantifeed.Excercise.Web.Controllers;
using Shouldly;
using Xunit;

namespace Quantifeed.Excercise.Web.Tests.Controllers
{
    public class HomeController_Tests: ExcerciseWebTestBase
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