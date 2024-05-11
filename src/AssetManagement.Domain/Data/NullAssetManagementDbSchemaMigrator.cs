using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;

namespace AssetManagement.Data;

/* This is used if the database provider does not define
 * an IAssetManagementDbSchemaMigrator implementation.
 */
public class NullAssetManagementDbSchemaMigrator : IAssetManagementDbSchemaMigrator, ITransientDependency
{
    private readonly ILogger<NullAssetManagementDbSchemaMigrator> _logger;

    public NullAssetManagementDbSchemaMigrator(ILogger<NullAssetManagementDbSchemaMigrator> logger)
    {
        _logger = logger;
    }

    public async Task MigrateAsync()
    {
        _logger.LogInformation("No database provider-specific implementation of IAssetManagementDbSchemaMigrator was found. Using the null migrator.");
        // Perform any necessary null operations here, if needed.
        await Task.CompletedTask;
    }
}
