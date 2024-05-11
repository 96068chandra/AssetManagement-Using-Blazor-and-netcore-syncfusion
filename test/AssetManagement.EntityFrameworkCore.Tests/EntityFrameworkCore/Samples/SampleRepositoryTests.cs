using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Xunit;

namespace AssetManagement.EntityFrameworkCore.Samples
{
    public class SampleRepositoryTests : AssetManagementEntityFrameworkCoreTestBase
    {
        private readonly IIdentityUserRepository _appUserRepository;

        public SampleRepositoryTests()
        {
            _appUserRepository = GetRequiredService<IIdentityUserRepository>();
        }

        [Fact]
        public async Task Should_Query_AppUser()
        {
            // Act
            var adminUser = await _appUserRepository.GetQueryableAsync()
                .FirstOrDefaultAsync(u => u.UserName == "admin");

            // Assert
            adminUser.ShouldNotBeNull();
        }
    }
}
