using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Identity;
using Xunit;

namespace AssetManagement.Samples;

public class SampleDomainTests : AssetManagementDomainTestBase
{
    private readonly IIdentityUserRepository _identityUserRepository;
    private readonly IdentityUserManager _identityUserManager;

    public SampleDomainTests()
    {
        _identityUserRepository = GetRequiredService<IIdentityUserRepository>();
        _identityUserManager = GetRequiredService<IdentityUserManager>();
    }

    [Fact]
    public async Task Should_Set_Email_Of_A_User()
    {
        // Use a variable name that describes what it is, not how it's used
        IdentityUser adminUser = await _identityUserRepository
            .FindByNormalizedUserNameAsync("ADMIN");

        // Use a variable name that describes what it is, not how it's used
        string newEmail = "newemail@abp.io";

        // Use a using block to ensure the Unit Of Work is disposed of properly
        using (var uow = UnitOfWorkManager.Begin())
        {
            await _identityUserManager.SetEmailAsync(adminUser, newEmail);
            await _identityUserRepository.UpdateAsync(adminUser);

            // Commit the Unit Of Work after all changes have been made
            await uow.CompleteAsync();
        }

        adminUser = await _identityUserRepository.FindByNormalizedUserNameAsync("ADMIN");
        adminUser.Email.ShouldBe(newEmail);
    }
}
