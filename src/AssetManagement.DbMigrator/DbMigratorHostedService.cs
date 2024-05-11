using System;
using System.Threading;
using System.Threading.Tasks;
using AssetManagement.Data;
using AssetManagement.DbMigrator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace AssetManagement.DbMigrator;

public class DbMigratorHostedService : IHostedService, ITransientDependency
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IConfiguration _configuration;
    private readonly AssetManagementDbMigrationService _migrationService;
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

    public DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime, IConfiguration configuration, AssetManagementDbMigrationService migrationService)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _configuration = configuration;
        _migrationService = migrationService;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            Log.Information("Starting database migration...");
            await _semaphore.WaitAsync(cancellationToken);

            using (var application = await AbpApplicationFactory.CreateAsync<AssetManagementDbMigratorModule>(options =>
            {
                options.Services.ReplaceConfiguration(_configuration);
                options.UseAutofac();
                options.Services.AddLogging(c => c.AddSerilog());
                options.AddDataMigrationEnvironment();
            }))
            {
                await application.InitializeAsync();

                await _migrationService.MigrateAsync();

                await application.InitializeDatabaseAsync();

                await application.ShutdownAsync();
            }

            Log.Information("Database migration completed successfully.");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "An error occurred during database migration.");
        }
        finally
        {
            _semaphore.Release();
            _hostApplicationLifetime.StopApplication();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
