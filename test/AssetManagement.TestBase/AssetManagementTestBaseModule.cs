using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace AssetManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpBackgroundJobsModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpTestBaseModule),
    typeof(AssetManagementDomainModule)
    )]
public class AssetManagementTestBaseModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options =>
        {
            options.IsJobExecutionEnabled = false;
        });

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.UseSqlite("Data Source=test;");
        });

        context.Services.AddAlwaysAllowAuthorization();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        SeedTestData(context).GetAwaiter().GetResult();
    }

    private async Task SeedTestData(ApplicationInitializationContext context)
    {
        using (var scope = context.ServiceProvider.CreateScope())
        {
            var dataSeeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
            await dataSeeder.SeedAsync();
        }
    }
}
