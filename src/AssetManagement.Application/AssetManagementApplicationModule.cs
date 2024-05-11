using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.SettingManagement;

namespace AssetManagement;

[DependsOn(
    typeof(AssetManagementDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(AssetManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class AssetManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AssetManagementApplicationModule>();
        });

        Configure<AbpFeatureManagementOptions>(options =>
        {
            // Configure any feature management options here
        });

        Configure<AbpTenantManagementOptions>(options =>
        {
            // Configure any tenant management options here
        });

        Configure<AbpPermissionManagementOptions>(options =>
        {
            // Configure any permission management options here
        });

        Configure<AbpSettingManagementOptions>(options =>
        {
            // Configure any setting management options here
        });
    }
}
