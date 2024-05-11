using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Volo.Abp;

namespace AssetManagement.DbMigrator
{
    /// <summary>
    /// Application entry point for the database migrator.
    /// </summary>
    class Program
    {
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Conditional(
                    w => w.Name == "Microsoft" && w.Level >= LogEventLevel.Warning,
                    c => c.File("Logs/logs.txt"))
                .WriteTo.Conditional(
                    w => w.Name == "Volo.Abp" && w.Level >= LogEventLevel.Warning,
                    c => c.File("Logs/logs.txt"))
#if DEBUG
                .WriteTo.Conditional(
                    w => w.Name == "AssetManagement" && w.Level >= LogEventLevel.Debug,
                    c => c.File("Logs/logs.txt"))
#else
                .WriteTo.Conditional(
                    w => w.Name == "AssetManagement" && w.Level >= LogEventLevel.Information,
                    c => c.File("Logs/logs.txt"))
#endif
                .WriteTo.Async(c => c.Console())
                .Enrich.FromLogContext()
                .CreateLogger();

            try
            {
                var logsDirectory = Environment.GetEnvironmentVariable("LOGS_DIRECTORY");
                string logFilePath = logsDirectory != null
                    ? Path.Combine(logsDirectory, "logs.txt")
                    : "Logs/logs.txt";

                Directory.CreateDirectory("Logs");

                Log.Logger = Log.Logger.WriteTo.File(logFilePath);

                await CreateHostBuilder(args).RunConsoleAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An unexpected error occurred in the database migrator.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .AddAppSettingsSecretsJson()
                .ConfigureLogging((context, logging) => logging.ClearProviders())
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<DbMigratorHostedService>();
                });
    }
}
