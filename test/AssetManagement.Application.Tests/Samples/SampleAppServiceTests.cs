using Shouldly;
using System.Threading.Tasks;
using AssetManagement.Identity;
using Xunit;

namespace AssetManagement.Tests;

public class IdentityAppServiceTests : AssetManagementApplicationTestBase
{
    private readonly IIdentityUserAppService _userAppService;

    public IdentityAppServiceTests()
    {
        _userAppService = GetRequiredService<IIdentityUserAppService>();
    }

    [Fact]
    public async Task Initial_Data_Should_Contain_Admin_User()
    {
        //Act
        var result = await _userAppService.GetListAsync(new GetIdentityUsersInput());

        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(user => user.UserName == "admin");
    }
}
