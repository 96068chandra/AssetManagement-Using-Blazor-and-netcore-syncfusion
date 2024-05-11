using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace AssetManagement.Blazor;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddAutofac();

        var host = builder.Build();

        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var application = host.Services.GetRequiredService<IApplication>();
            await application.InitializeAsync(services);
            await host.RunAsync();
        }
        catch (Exception ex)
        {
            // Log the exception
            // ...
            throw;
        }
    }
}

public interface IApplication
{
    Task InitializeAsync(IServiceProvider services);
}

public class AssetManagementBlazorModule : Module, IApplication
{
    public async Task InitializeAsync(IServiceProvider services)
    {
        // Perform any necessary initialization here
        // ...

        await Task.CompletedTask;
    }
}
