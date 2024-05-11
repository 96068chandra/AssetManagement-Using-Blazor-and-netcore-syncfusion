using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace AssetManagement;

public class AssetManagementModuleExtensionConfigurator : IModule
{
    private readonly OneTimeRunner _oneTimeRunner = new OneTimeRunner();

    public void ConfigureServices(ServiceConfigurationContext context)
    {
        _oneTimeRunner.Run(() =>
        {
            ConfigureExistingProperties();
            ConfigureExtraProperties();
        });
    }

    private void ConfigureExistingProperties()
    {
        // Change user and role name max lengths
        IdentityUserConsts.MaxNameLength = 99;
        IdentityRoleConsts.MaxNameLength = 99;

        // If using EF Core, run the add-migration command after changes
        if (AbpBootstrapper.Current.ApplicationServiceProvider.GetService<IDbContextFactory<IdentityDbContext>>() is not null)
        {
            AsyncHelper.RunSync(async () =>
            {
                using var dbContext = AbpBootstrapper.Current.ApplicationServiceProvider.GetService<IDbContextFactory<IdentityDbContext>>().CreateDbContext();
                await dbContext.Database.MigrateAsync();
            });
        }
    }

    private void ConfigureExtraProperties()
    {
        ObjectExtensionManager.Instance.Modules()
            .ConfigureIdentity(identity =>
            {
                identity.ConfigureUser(user =>
                {
                    user.AddOrUpdateProperty<string>(
                        "SocialSecurityNumber",
                        property =>
                        {
                            // Validation rules
                            property.Attributes.Add(new RequiredAttribute());
                            property.Attributes.Add(new StringLengthAttribute(64) { MinimumLength = 4 });

                            property.Configuration[IdentityModuleExtensionConsts.ConfigurationNames.AllowUserToEdit] = true;

                            // ...other configurations for this property
                        });
                });
            });
    }
}
