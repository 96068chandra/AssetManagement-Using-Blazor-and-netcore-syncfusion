using Volo.Abp.Modularity;

namespace AssetManagement;

[DependsOn(
    typeof(AssetManagementApplicationModule),
    typeof(AssetManagementDomainTestModule)
    )]
public class AssetManagementApplicationTestModule : AbpModule
{

}
