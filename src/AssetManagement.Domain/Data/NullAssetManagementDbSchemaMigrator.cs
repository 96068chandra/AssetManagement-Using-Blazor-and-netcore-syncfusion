using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AssetManagement.Data;

/* This is used if database provider does't define
 * IAssetManagementDbSchemaMigrator implementation.
 */
public class NullAssetManagementDbSchemaMigrator : IAssetManagementDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
