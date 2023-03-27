using AssetManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AssetManagement.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AssetManagementEntityFrameworkCoreModule),
    typeof(AssetManagementApplicationContractsModule)
    )]
public class AssetManagementDbMigratorModule : AbpModule
{

}
