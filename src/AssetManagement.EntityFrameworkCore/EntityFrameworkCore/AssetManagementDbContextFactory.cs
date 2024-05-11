using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AssetManagement.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AssetManagementDbContextFactory : IDesignTimeDbContextFactory<AssetManagementDbContext>
{
    public AssetManagementDbContext CreateDbContext(string[] args)
    {
        // Configure EntityTypeConfiguration classes here
        AssetManagementEfCoreEntityExtensionMappings.Configure();

        // Build the configuration
        var configuration = BuildConfiguration();

        // Use the connection string from the configuration
        var builder = new DbContextOptionsBuilder<AssetManagementDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        // Return the created DbContext instance
        return new AssetManagementDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        // Set the base path to the current directory,
        // one level up from the data access project
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        return builder.Build();
    }
}
