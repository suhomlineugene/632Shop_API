using SixThreeTwo_shop.Models.TokenAuth;
using SixThreeTwo_shop.Web.Controllers;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace SixThreeTwo_shop.Web.Tests.Controllers;

public class HomeController_Tests : SixThreeTwo_shopWebTestBase
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