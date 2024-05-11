using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AssetManagement.HttpApi.Client.ConsoleTestApp;

[Deprecated(Reason = "Use AssetManagementConsoleApiClientModule instead.")]
public class ConsoleTestAppHostedService : IHostedService
{
    private readonly IConfiguration _configuration;
    private readonly IServiceProvider _serviceProvider;

    public ConsoleTestAppHostedService(IConfiguration configuration, IServiceProvider serviceProvider)
    {
        _configuration = configuration;
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            using (var application = await AbpApplicationFactory.CreateAsync<AssetManagementConsoleApiClientModule>(options =>
            {
                options.Services.ReplaceConfiguration(_configuration);
                options.UseAutofac();
            }))
            {
                await application.InitializeAsync();

                var demo = _serviceProvider.GetRequiredService<ClientDemoService>();
                await demo.RunAsync();

                await application.ShutdownAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
