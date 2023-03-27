using System.Threading.Tasks;

namespace AssetManagement.Data;

public interface IAssetManagementDbSchemaMigrator
{
    Task MigrateAsync();
}
