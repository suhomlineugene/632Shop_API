using 632Shop.Models.TokenAuth;
using 632Shop.Web.Controllers;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace 632Shop.Web.Tests.Controllers;

public class HomeController_Tests : 632ShopWebTestBase
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