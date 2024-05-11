using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectExtending;

namespace AssetManagement;

[DependsOn(
    typeof(AssetManagementDomainSharedModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpObjectExtendingModule)
)]
public class AssetManagementApplicationContractsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpApplicationServiceOptions>(options =>
        {
            options.UseAuthenticate = true;
        });

        AssetManagementDtoExtensions.Configure();
    }
}
