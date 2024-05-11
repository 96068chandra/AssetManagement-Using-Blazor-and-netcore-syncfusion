using System;
using System.Threading.Tasks;

namespace AssetManagement.Data
{
    public interface IAssetManagementDbSchemaMigrator
    {
        Task MigrateAsync();
    }

    public class AssetManagementDbSchemaMigrator : IAssetManagementDbSchemaMigrator
    {
        private readonly string _connectionString;

        public AssetManagementDbSchemaMigrator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task MigrateAsync()
        {
            // Implementation to migrate the database schema goes here.
            // For example, using an ORM like Entity Framework Core:
            using (var dbContext = new AssetManagementDbContext(_connectionString))
            {
                await dbContext.Database.MigrateAsync();
            }
        }
    }
}
