using AssetManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AssetManagement;

[DependsOn(
    typeof(AssetManagementEntityFrameworkCoreTestModule)
    )]
public class AssetManagementDomainTestModule : AbpModule
{

}
